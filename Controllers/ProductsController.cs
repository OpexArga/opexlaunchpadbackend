using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpexShowcase.Data;
using OpexShowcase.Models;
using System.Security.Claims;

namespace OpexShowcase.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ GET: /api/products
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var products = await _context.Products
            .Include(p => p.ProductTags)
            .ToListAsync();

        // Mapping ke DTO biar lebih aman dan ringan
        var result = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            Tags = p.ProductTags.Select(tag => tag.Tag).ToList()
        }).ToList();

        return Ok(result);
    }

    // ✅ POST: /api/products/{id}/try
    [Authorize]
    [HttpPost("{id}/try")]
    public async Task<IActionResult> TryProduct(int id)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString == null)
            return Unauthorized("User ID not found in token");

        if (!int.TryParse(userIdString, out var userId))
            return Unauthorized("Invalid user ID");

        var productExists = await _context.Products.AnyAsync(p => p.Id == id);
        if (!productExists)
            return NotFound("Product not found");

        var alreadyTried = await _context.UserProducts
            .AnyAsync(up => up.UserId == userId && up.ProductId == id);
        if (alreadyTried)
            return BadRequest("You already tried this product");

        var userProduct = new UserProduct
        {
            UserId = userId,
            ProductId = id
        };

        _context.UserProducts.Add(userProduct);
        await _context.SaveChangesAsync();

        return Ok("Product saved to your account");
    }
}

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

    // GET: /api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // POST: /api/products/{id}/try
    [Authorize]
    [HttpPost("{id}/try")]
    public async Task<IActionResult> TryProduct(int id)
    {
        // 1. Ambil userId dari JWT token
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdString == null) return Unauthorized("User ID not found in token");

        if (!int.TryParse(userIdString, out var userId))
            return Unauthorized("Invalid user ID");

        // 2. Pastikan produk ada
        var productExists = await _context.Products.AnyAsync(p => p.Id == id);
        if (!productExists)
            return NotFound("Product not found");

        // 3. Cek apakah user sudah try
        var alreadyTried = await _context.UserProducts
            .AnyAsync(up => up.UserId == userId && up.ProductId == id);
        if (alreadyTried)
            return BadRequest("You already tried this product");

        // 4. Simpan relasi try product
        var userProduct = new UserProduct
        {
            UserId = userId,
            ProductId = id,
            User = null!,
            Product = null!
        };

        _context.UserProducts.Add(userProduct);
        await _context.SaveChangesAsync();

        return Ok("Product saved to your account");
    }
}

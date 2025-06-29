using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpexShowcase.Data;
using OpexShowcase.Models;

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

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
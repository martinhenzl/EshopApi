using EshopApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace EshopApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductDbContext _context;

    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    [HttpGet("all")]
    public IActionResult GetAllProducts()
    {
        return Ok(_context.Products.ToList());
    }

    /// <summary>
    /// Retrieves paginated list of products.
    /// </summary>
    /// <param name="pageNumber">Page number (default: 1)</param>
    /// <param name="pageSize">Page size (default: 10)</param>
    [HttpGet("v2")]
    public IActionResult GetProducts(int pageNumber = 1, int pageSize = 10)
    {
        var products = _context.Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok(products);
    }

    /// <summary>
    /// Retrieves a single product by ID.
    /// </summary>
    /// <param name="id">Product ID</param>
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    ///// <summary>
    ///// Updates the description of a product.
    ///// </summary>
    ///// <param name="id">Product ID</param>
    ///// <param name="description">New description</param>
    //[HttpPatch("{id}")]
    //public IActionResult UpdateProductDescription(int id, [FromBody] string description)
    //{
    //    var product = _context.Products.Find(id);
    //    if (product == null) return NotFound();
    //    product.Description = description;
    //    _context.SaveChanges();
    //    return NoContent();
    //}

    /// <summary>
    /// Updates the description of a product.
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <param name="dto">New description object</param>
    [HttpPatch("{id}")]    public IActionResult UpdateProductDescription(int id, [FromBody] UpdateDescriptionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = _context.Products.Find(id);
        if (product == null) return NotFound();
        product.Description = dto.Description;
        _context.SaveChanges();
        return NoContent();
    }
}
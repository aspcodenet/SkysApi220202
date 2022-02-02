using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SkysApi220202.Data;

namespace SkysApi220202.Controllers;

[ApiController]
[EnableCors("AllowAll")]
[Route("api/[controller]")] //Surfa till /api/product
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]  // R
    public IEnumerable<ProductDTO> Get()
    {
        return _context.Products.Select(e => new ProductDTO
        {
            Color = e.Color,
            Ean13 = e.Ean13,
            Id = e.Id,
            LastBought = e.LastBought,
            Name = e.Name,
            PopularityPercent = e.PopularityPercent,
            Price = e.Price
        });
    }


    [HttpGet]  // R 24
    [Route("{id}")]   
    public IActionResult GetSingle(int id)
    {
        var product = _context.Products.Where(e=>e.Id == id).Select(e => new ProductDTO
        {
            Color = e.Color,
            Ean13 = e.Ean13,
            Id = e.Id,
            LastBought = e.LastBought,
            Name = e.Name,
            PopularityPercent = e.PopularityPercent,
            Price = e.Price
        }).FirstOrDefault();
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<ProductDTO> Create(ProductNewDTO model)
    {
        var product = new Product
        {
            Color = model.Color,
            Created = DateTime.UtcNow,
            Ean13 = model.Ean13,
            LastBought = new DateTime(1900,1,1),
            Name = model.Name,
            PopularityPercent = model.PopularityPercent,
            Price = model.Price
        };
        _context.Products.Add(product);
        _context.SaveChanges();
        int id = product.Id;
        var obj = new ProductDTO();
        //map
        obj.Color = product.Color;
        obj.Ean13 = product.Ean13;
        obj.LastBought = product.LastBought;
        obj.Name = product.Name;
        obj.PopularityPercent = product.PopularityPercent;
        obj.Price = product.Price;

        return CreatedAtAction(nameof(GetSingle), new { id = id }, obj);
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductDTO model)
    {
        var product = _context.Products.FirstOrDefault(e =>
            e.Id == id);
        if (product == null) return NotFound();
        product.Color = model.Color;
        product.Ean13 = model.Ean13;
        product.LastBought = model.LastBought;
        product.Name = model.Name;
        product.PopularityPercent = model.PopularityPercent;
        product.Price = model.Price;
        _context.SaveChanges();
        return NoContent();

    }






}
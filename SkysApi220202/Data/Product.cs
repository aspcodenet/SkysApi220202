using System.ComponentModel.DataAnnotations;

namespace SkysApi220202.Data;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    [MaxLength(20)]
    public string Color { get; set; }
    [MaxLength(15)]
    public string Ean13 { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastBought { get; set; }

    public int PopularityPercent { get; set; }
}
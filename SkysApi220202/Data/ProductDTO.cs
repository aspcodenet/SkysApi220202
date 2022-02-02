namespace SkysApi220202.Data;

public class ProductDTO
{
    public int Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public string Ean13 { get; set; }
    public DateTime LastBought { get; set; }

    public int PopularityPercent { get; set; }

}
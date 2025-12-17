using System.ComponentModel.DataAnnotations.Schema;

namespace Ntigra.Ecommerce.Platform.Domain.Product;

[Table("t_product")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("discount_percent")]
    public int DiscountPercent { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }
}

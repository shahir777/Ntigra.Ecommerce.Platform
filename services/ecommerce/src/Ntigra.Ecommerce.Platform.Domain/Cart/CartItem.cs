using System.ComponentModel.DataAnnotations.Schema;
using Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;

namespace Ntigra.Ecommerce.Platform.Domain.Cart;

[Table("t_cart_items", Schema = "public")]
public class CartItem
{
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product.Product Product { get; set; }
    
    [NotMapped]
    public bool IsEmpty => Quantity == 0;
    public void RemoveQuantity(int quantity = 1)
    {
        if (Quantity < 0)
            throw new DomainException("Quantity must be positive");

        Quantity -= quantity;
    }
    
    public void AddQuantity(int quantity = 1)
    {
        if (Quantity < 0)
            throw new DomainException("Quantity must be positive");

        Quantity += quantity;
    }
}


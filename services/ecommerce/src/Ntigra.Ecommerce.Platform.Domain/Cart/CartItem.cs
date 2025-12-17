using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Cart;

[Table("t_cart_items")]
public class CartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public Domain.Product.Product Product { get; set; }
}


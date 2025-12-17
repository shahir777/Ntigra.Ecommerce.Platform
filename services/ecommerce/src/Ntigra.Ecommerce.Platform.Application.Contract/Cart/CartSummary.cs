using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Cart;
public class CartSummary
{
    public List<CartItemSummary> Items { get; set; } = [];
    public decimal TotalPrice { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal FinalPrice => TotalPrice - TotalDiscount;
    public bool HasDiscount => TotalDiscount > 0;
}

public class CartItemSummary
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal OriginalPrice { get; set; }
    public int DiscountPercent { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalPrice => OriginalPrice - DiscountAmount;
    public int Quantity { get; set; }
}
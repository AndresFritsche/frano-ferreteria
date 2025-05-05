using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frano_ferreteria.Models;

public class Bill
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }

    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Quantity * UnitPrice;
    public string? PaymentMethod { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
}

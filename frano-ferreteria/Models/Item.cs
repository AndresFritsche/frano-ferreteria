using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Constraints;

namespace frano_ferreteria.Models;

public class Item
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Descrition { get; set; }
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
    public int BillId { get; set; }
    [ForeignKey("BillId")]
    public decimal Total => Stock * UnitPrice;
    public Bill Bill { get; set; } = new Bill();
}

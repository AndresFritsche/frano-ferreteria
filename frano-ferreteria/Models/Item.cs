using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frano_ferreteria.Models;

public class Item
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Descrition { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

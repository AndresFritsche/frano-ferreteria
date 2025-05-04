using System;

namespace frano_ferreteria.Models;

public class Bill
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string? NombreCliente { get; set; }

    public decimal Total { get; set; }
}

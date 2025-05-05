using System;
using frano_ferreteria.Models;
using Microsoft.EntityFrameworkCore;

namespace frano_ferreteria;

public class FranoContext : DbContext
{
    public FranoContext(DbContextOptions<FranoContext> options): base (options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Bill> Bills { get; set; }

}

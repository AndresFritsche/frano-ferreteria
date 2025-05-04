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

}

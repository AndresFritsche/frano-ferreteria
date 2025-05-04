using System;
using Microsoft.EntityFrameworkCore;

namespace frano_ferreteria;

public class FranoContext : DbContext
{
    public FranoContext(DbContextOptions<FranoContext> options): base (options)
    {
        
    }
}

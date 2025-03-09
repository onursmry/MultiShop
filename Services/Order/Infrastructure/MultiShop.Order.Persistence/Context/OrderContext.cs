using MultiShop.Order.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    private readonly IConfiguration _configuration;

    public OrderContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
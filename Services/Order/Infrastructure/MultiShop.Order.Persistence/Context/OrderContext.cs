using MultiShop.Order.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server =localhost,1434; initial Catalog = MultiShopOrderDb; TrustServerCertificate = true;User=sa;Password=Multishop1!");
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
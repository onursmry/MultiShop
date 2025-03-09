using Microsoft.EntityFrameworkCore;
using MultiShop.Review.Entities;

public class ReviewContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ReviewContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<UserReview> UserReviews { get; set; }
}
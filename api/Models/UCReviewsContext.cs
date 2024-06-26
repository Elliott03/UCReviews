namespace api.Models;
using Microsoft.EntityFrameworkCore;

public class UCReviewsContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Building> Building { get; set; }
    public UCReviewsContext(DbContextOptions<UCReviewsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>()
        .HasMany(u => u.Reviews)
        .WithOne(r => r.User)
        .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Building>()
        .HasMany(b => b.Reviews)
        .WithOne(r => r.Building)
        .HasForeignKey(r => r.BuildingId);

        base.OnModelCreating(modelBuilder);
    }
}
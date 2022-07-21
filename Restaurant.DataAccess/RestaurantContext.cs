namespace Restaurant.DataAccess;

using Data.Models;
using Microsoft.EntityFrameworkCore;
using ModelMappings;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options): base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserMap());
    }
}
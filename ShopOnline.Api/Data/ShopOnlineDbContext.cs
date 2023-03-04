using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class ShopOnlineDbContext: DbContext
    {
        public ShopOnlineDbContext (DbContextOptions<ShopOnlineDbContext> options) : base(options) 
        { 

        }

        public DbSet<Cart> Carts { get;set; }
        public DbSet<CartItem> CartItems { get;set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<ProductCategory> ProductCategories { get;set; }
        public DbSet<User> Users { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<User>()
                        .HasOne(a => a.Cart)
                        .WithOne(b => b.User)
                        .HasForeignKey<Cart>(b=>b.UserId);

        }
    }
}

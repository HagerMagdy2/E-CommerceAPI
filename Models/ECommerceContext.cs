

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Models
{
    public class ECommerceContext:IdentityDbContext
    {


        // public ECommerceContext(DbContextOptions<ECommerceContext> Option):base(Option) { }
        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {
            
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderDetails>().HasKey("order_id", "product_id");
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "customer", NormalizedName = "CUSTOMER" }
                );
        }
    }
}

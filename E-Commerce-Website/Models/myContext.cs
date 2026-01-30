using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options) : base(options)
        {

        }

        // Admin Model
        public DbSet<Admin> tbl_admin { get; set; }
        
        // Customer Model
        public DbSet<Customer> tbl_customer { get; set; }

        // Category Model
        public DbSet<Category> tbl_category { get; set; }

        // Product Model
        public DbSet<Product> tbl_product { get; set; }

        // Cart Model 
        public DbSet<Cart> tbl_cart { get; set; }

        // Feedback Model 
        public DbSet<Feedback> tbl_feedback { get; set; }

        // Faqs Model 
        public DbSet<Faqs> tbl_faqs { get; set; }

        // Fluid Model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // Add Foreign key Model for method reference  
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.cat_id);
        }




    }
}

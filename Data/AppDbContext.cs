using Microsoft.EntityFrameworkCore;
using OpexShowcase.Models;

namespace OpexShowcase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Opex AI",
                Slug = "opexai",
                Description = "Unlock AI-powered efficiency by connecting your ERP and enterprise systems seamlessly.",
                ImageUrl = "/images/products/opexai.jpg",
                Price = 0
            },
            new Product
            {
                Id = 2,
                Name = "Opex eInvoice",
                Slug = "opexeinvoice",
                Description = "Digitize your invoicing process with legally compliant e-Invoicing integrated with your system.",
                ImageUrl = "/images/products/einvoice.jpg",
                Price = 0
            },
            new Product
            {
                Id = 3,
                Name = "Opex eMeterai",
                Slug = "opexemeterai",
                Description = "Simplify digital stamping with seamless e-Meterai issuance, legally valid and efficient.",
                ImageUrl = "/images/products/emeterai.jpg",
                Price = 0
            }
        );

            modelBuilder.Entity<ProductTag>().HasData(
                new ProductTag { Id = 1, ProductId = 1, Tag = "Scalable Cloud Infrastructure" },
                new ProductTag { Id = 2, ProductId = 1, Tag = "Expert Support" },
                new ProductTag { Id = 3, ProductId = 1, Tag = "Custom Workflow" },
                new ProductTag { Id = 4, ProductId = 2, Tag = "Secure & Compliant" },
                new ProductTag { Id = 5, ProductId = 2, Tag = "Real-time Sync" },
                new ProductTag { Id = 6, ProductId = 2, Tag = "Easy Integration" },
                new ProductTag { Id = 7, ProductId = 3, Tag = "Official Certified Stamping" },
                new ProductTag { Id = 8, ProductId = 3, Tag = "Bulk Upload Ready" },
                new ProductTag { Id = 9, ProductId = 3, Tag = "Simple Interface" }
            );
            // Composite key untuk tabel relasi
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.ProductId });

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts)
                .HasForeignKey(up => up.ProductId);
        }
    }
}

using HoangHongNhung152465.Entities;
using Microsoft.EntityFrameworkCore;

namespace HoangHongNhung152465.DbContexts
{
    public class ApplicationDbContext152465De2 : DbContext
    {
        public DbSet<Product152465De2> Products { get; set; }
        public DbSet<Certificate152465De2> Certificates { get; set; }
        public DbSet<ProductCertificate152465De2> ProductCertificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCertificate152465De2>()
                 .HasKey(ss => ss.Id);
            modelBuilder.Entity<ProductCertificate152465De2>()
                .HasOne<Product152465De2>()
                .WithMany()
                .HasForeignKey(ss => ss.ProductId);
            modelBuilder.Entity<ProductCertificate152465De2>()
                .HasOne<Certificate152465De2>()
                .WithMany()
                .HasForeignKey(ss => ss.CertificateId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O3Q4RPU;Initial Catalog=Product;Integrated Security=True;TrustServerCertificate=True;");
        }

    }
}

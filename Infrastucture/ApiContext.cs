using CatalogoDeProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeProdutos.Infrastucture
{
    public class ApiContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApiContext(DbContextOptions<ApiContext> opts, IConfiguration configuration) : base(opts)
        {

            _configuration = configuration;

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);

            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);



        }

    }
}

using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id= 1,
                    Name = "Luva",
                    Description ="Luva tamanho 9",
                    ImageURL = "https://img.irroba.com.br/filters:fill(fff):quality(80)/soaquife/catalog/luva-profissional-ldi/luva-mecanico-02safetytato-alta-sensibilidade-pu-8010.jpg",
                    Price =25,
                    CreatedAt = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    Name = "Mascara",
                    Description = "Mascara descartavel",
                    ImageURL = "https://cdn.awsli.com.br/2126/2126528/produto/135495613/f871fa1a82.jpg",
                    Price = 5,
                    CreatedAt = DateTime.Now,
                }
                );
        }
    }
}

using _2280600149_HoangAn3.Models;
using Microsoft.EntityFrameworkCore;

namespace _2280600149_HoangAn3.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync (int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task SeedDataAsync()
        {
            if (await _context.Products.AnyAsync() || await _context.Categories.AnyAsync())
            {
                return; // Data already exists
            }

            // Add Categories if they don't exist
            var categories = new[]
            {
                    new Category { Name = "Electronics" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Books" },
                    new Category { Name = "Home & Garden" }
                };

            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            // Add Products
            var products = new[]
            {
                    new Product
                    {
                        Name = "Smartphone X1",
                        Price = 999.99M,
                        Description = "Latest generation smartphone with advanced features",
                        CategoryId = categories[0].Id,
                        ImageUrl = "/images/products/smartphone.jpg"
                    },
                    new Product
                    {
                        Name = "Laptop Pro",
                        Price = 1499.99M,
                        Description = "High-performance laptop for professionals",
                        CategoryId = categories[0].Id,
                        ImageUrl = "/images/products/laptop.jpg"
                    },
                    new Product
                    {
                        Name = "Cotton T-Shirt",
                        Price = 24.99M,
                        Description = "Comfortable cotton t-shirt, available in multiple colors",
                        CategoryId = categories[1].Id,
                        ImageUrl = "/images/products/tshirt.jpg"
                    },
                    new Product
                    {
                        Name = "Programming Guide 2025",
                        Price = 49.99M,
                        Description = "Comprehensive programming guide for modern development",
                        CategoryId = categories[2].Id,
                        ImageUrl = "/images/products/book.jpg"
                    },
                    new Product
                    {
                        Name = "Garden Tool Set",
                        Price = 89.99M,
                        Description = "Complete set of essential garden tools",
                        CategoryId = categories[3].Id,
                        ImageUrl = "/images/products/tools.jpg"
                    }
            };

            await _context.Products.AddRangeAsync(products);
        }
    }
}

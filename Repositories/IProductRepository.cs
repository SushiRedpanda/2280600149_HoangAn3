using _2280600149_HoangAn3.Models;

namespace _2280600149_HoangAn3.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync (Product product);
        Task DeleteAsync (int id);
    }
}

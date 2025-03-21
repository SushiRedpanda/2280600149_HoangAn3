﻿using _2280600149_HoangAn3.Models;

namespace _2280600149_HoangAn3.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddSync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}

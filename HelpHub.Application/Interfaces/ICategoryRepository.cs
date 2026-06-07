using HelpHub.Domain.Entities;

namespace HelpHub.Application.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category> CreateAsync(Category category);

    Task<bool> UpdateAsync(Category category);

    Task<bool> DeleteAsync(int id);
}
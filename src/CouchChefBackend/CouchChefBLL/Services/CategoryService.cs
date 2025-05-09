using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Services;

public class CategoryService : ICategoryService
{
    private readonly CouchChefDbContext _context;
    public CategoryService(CouchChefDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddCategoryAsync(CategoryDTO categoryDTO)
    {
        var category = new Category
        {
            Name = categoryDTO.Name,
            Id = 0
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category.Id;
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null)
        {
            throw new KeyNotFoundException($"Category with id {id} not found.");
        }
        return new CategoryDTO { Id = category.Id, Name = category.Name };
    }
}

using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        var categoriesDTOs = categories.Select(x => new CategoryDTO
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
        return categoriesDTOs;
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
    {
        var category = await GetCategoryAsync(id);
        return new CategoryDTO { Id = category.Id, Name = category.Name };
    }

    public async Task UpdateCategoryAsync(int id, string Name)
    {
        var category = await GetCategoryAsync(id);
        category.Name = Name;
        await _context.SaveChangesAsync();
    }

    private async Task<Category> GetCategoryAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category is null)
        {
            throw new KeyNotFoundException($"Category with id {id} not found.");
        }
        return category;
    }
}

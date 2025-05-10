using CouchChefBLL.DTOs;

namespace CouchChefBLL.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDTO>> GetAllCategoriesAsync();
    Task<int> AddCategoryAsync(CategoryDTO categoryDTO);
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
    Task UpdateCategoryAsync(int id, string Name);
    Task DeleteCategoryAsync(int id);
}

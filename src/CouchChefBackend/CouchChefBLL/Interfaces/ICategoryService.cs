using CouchChefBLL.DTOs;

namespace CouchChefBLL.Interfaces;

public interface ICategoryService
{
    Task<int> AddCategoryAsync(CategoryDTO categoryDTO);
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
}

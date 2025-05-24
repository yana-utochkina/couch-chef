using CouchChefBLL.DTOs;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Filters;

namespace CouchChefBLL.Interfaces;

public interface IRecipeService
{
    Task<PostRecipeDTO> CreateRecipeAsync(PostRecipeDTO postRecipeDTO);
    Task<RecipeDTO> GetRecipeAsync(int id);
    Task<List<RecipeDTO>> GetRecipesAsync(RecipeFilters filters);
}

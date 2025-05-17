using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;

namespace CouchChefBLL.Interfaces;

public interface IRecipeService
{
    Task<int> AddRecipeAsync(PostRecipeDTO postRecipeDTO);
    Task<GetRecipeDTO> GetRecipeAsync(int id);
}

using CouchChefBLL.DTOs;
using CouchChefBLL.DTOs.Post;

namespace CouchChefBLL.Interfaces;

public interface IIngredientService
{
    Task<PostIngredientDTO> CreateIngredientAsync(PostIngredientDTO postIngredientDTO);
    Task<IngredientDTO> GetIngredientAsync(int id);
    Task<List<IngredientDTO>> GetAllAsync();
    Task DeleteIngredientAsync(int id);
    Task <PostIngredientDTO>UpdateIngredientAsync(int id, PostIngredientDTO postIngredientDTO);
}

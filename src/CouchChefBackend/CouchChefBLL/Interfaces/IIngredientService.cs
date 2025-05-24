using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;

namespace CouchChefBLL.Interfaces;

public interface IIngredientService
{
    Task<PostIngredientDTO> CreateIngredientAsync(PostIngredientDTO postIngredientDTO);
    Task<GetIngredientDTO> GetIngredientAsync(int id);
    Task<List<GetIngredientDTO>> GetAllAsync();
    Task DeleteIngredientAsync(int id);
    Task <PostIngredientDTO>UpdateIngredientAsync(int id, PostIngredientDTO postIngredientDTO);
}

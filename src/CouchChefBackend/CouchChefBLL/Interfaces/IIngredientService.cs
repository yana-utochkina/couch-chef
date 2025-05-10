using CouchChefBLL.DTOs;

namespace CouchChefBLL.Interfaces;

public interface IIngredientService
{
    Task<int> AddIngredientAsync(IngredientDTO ingredientDTO);
    Task<IngredientDTO> GetIngredientAsync(int id);
}

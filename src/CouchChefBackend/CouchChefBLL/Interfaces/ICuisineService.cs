using CouchChefBLL.DTOs.Get;

namespace CouchChefBLL.Interfaces;

public interface ICuisineService
{
    Task<List<GetCuisineDTO>> GelAllCuisinesAsync();
    Task<int> AddCuisineAsync(GetCuisineDTO cuisineDTO);
    Task<GetCuisineDTO> GetCuisineAsync(int id);
    Task UpdateCuisineAsync(int id,  GetCuisineDTO cuisineDTO);
    Task DeleteCuisineByIdAsync(int id);
}

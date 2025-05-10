using CouchChefBLL.DTOs;

namespace CouchChefBLL.Interfaces;

public interface ICuisineService
{
    Task<List<CuisineDTO>> GelAllCuisinesAsync();
    Task<int> AddCuisineAsync(CuisineDTO cuisineDTO);
    Task<CuisineDTO> GetCuisineAsync(int id);
    Task UpdateCuisineAsync(int id,  CuisineDTO cuisineDTO);
    Task DeleteCuisineByIdAsync(int id);
}

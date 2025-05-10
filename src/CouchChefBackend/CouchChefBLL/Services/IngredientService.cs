using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Services;

public class IngredientService : IIngredientService
{
    private readonly CouchChefDbContext _context;

    public IngredientService(CouchChefDbContext context)
    {
        _context = context;
    }
    public Task<int> AddIngredientAsync(IngredientDTO ingredientDTO)
    {
        //
        throw new NotImplementedException();
    }

    public Task<IngredientDTO> GetIngredientAsync(int id)
    {
        throw new NotImplementedException();
    }
}

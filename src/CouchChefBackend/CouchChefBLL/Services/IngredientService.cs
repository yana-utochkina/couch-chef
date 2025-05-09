using CouchChefBLL.Interfaces;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Services;

public class IngredientService : IIngredientService
{
    public Task<int> AddAsync(Ingredient entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Ingredient entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Ingredient entity)
    {
        throw new NotImplementedException();
    }
}

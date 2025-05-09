using CouchChefBLL.Interfaces;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Services;

public class RecipeService : IRecipeService
{
    public Task<int> AddAsync(Recipe entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Recipe entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recipe>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Recipe> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Recipe entity)
    {
        throw new NotImplementedException();
    }
}

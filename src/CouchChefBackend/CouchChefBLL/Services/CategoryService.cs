using CouchChefBLL.Interfaces;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Services;

public class CategoryService : ICategoryService
{
    public Task<int> AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }
}

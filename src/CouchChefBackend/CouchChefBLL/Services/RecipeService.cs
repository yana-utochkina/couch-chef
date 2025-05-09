using AutoMapper;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Models;
using CouchChefDAL.Interfaces;

namespace CouchChefBLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddAsync(RecipeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RecipeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RecipeModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RecipeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

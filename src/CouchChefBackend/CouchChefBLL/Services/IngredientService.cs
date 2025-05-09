using AutoMapper;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Models;
using CouchChefDAL.Interfaces;

namespace CouchChefBLL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddAsync(IngredientModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IngredientModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IngredientModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IngredientModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IngredientModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

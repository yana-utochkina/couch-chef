using AutoMapper;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Models;
using CouchChefDAL.Interfaces;

namespace CouchChefBLL.Services
{
    public class CuisineService : ICuisineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuisineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Task<int> AddAsync(CuisineModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CuisineModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CuisineModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CuisineModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CuisineModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

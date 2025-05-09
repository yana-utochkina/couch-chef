using AutoMapper;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Models;
using CouchChefDAL.Interfaces;

namespace CouchChefBLL.Services
{
    public class AdviseService : IAdviseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdviseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddAsync(AdviseModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AdviseModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdviseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AdviseModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AdviseModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

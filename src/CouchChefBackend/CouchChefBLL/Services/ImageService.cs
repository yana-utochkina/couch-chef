using AutoMapper;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Models;
using CouchChefDAL.Interfaces;

namespace CouchChefBLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddAsync(ImageModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ImageModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ImageModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImageModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ImageModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Interfaces;

public interface IImageService
{
    Task<Image> AddImageAsync(PostImageDTO postImageDTO);
    Task<GetImageDTO> GetImageAsync(int id);
    Task DeleteImageAsync(int id);
    Task UpdateImageAsync(int id, string alternativeText);
    Task<List<GetImageDTO>> GetAllAsync();
}

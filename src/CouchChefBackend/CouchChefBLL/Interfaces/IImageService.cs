using CouchChefBLL.DTOs;

namespace CouchChefBLL.Interfaces;

public interface IImageService
{
    Task<int> AddImageAsync(ImageDTO imageDTO);
    Task<ImageDTO> GetImageAsync(int id);
    Task DeleteImageAsync(int id);
    Task UpdateImageAsync(int id, string alternativeText);
    Task<List<ImageDTO>> GetAllAsync();
}

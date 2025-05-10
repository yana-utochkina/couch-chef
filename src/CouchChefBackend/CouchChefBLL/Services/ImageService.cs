using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class ImageService : IImageService
{
    private readonly CouchChefDbContext _context;
    private readonly IStaticFileService _fileServices;
    public ImageService(CouchChefDbContext context, IStaticFileService fileService)
    {
        _context = context;
        _fileServices = fileService;
    }

    public async Task<int> AddImageAsync(ImageDTO imageDTO)
    {
        var image = new Image
        {
            Id = 0,
            Path = imageDTO.Path,
            AlternativeText = imageDTO.AlternativeText,
        };
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return image.Id;
    }

    public async Task DeleteImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        _fileServices.Remove(image.Path);
        _context.Remove(image);
        await _context.SaveChangesAsync();
    }

    public async Task<ImageDTO> GetImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        var imageDTO = new ImageDTO
        {
            Id = image.Id,
            Path = image.Path,
            AlternativeText = image.AlternativeText,
        };
        return imageDTO;
    }

    public async Task UpdateImageAsync(int id, string alternativeText)
    {
        var image = await GetImageByIdAsync(id);
        image.AlternativeText = alternativeText;
        await _context.SaveChangesAsync();
    }

    private async Task<Image> GetImageByIdAsync(int id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        if (image is null)
        {
            throw new KeyNotFoundException($"Image with id {id} not found.");
        }
        return image;
    }
}

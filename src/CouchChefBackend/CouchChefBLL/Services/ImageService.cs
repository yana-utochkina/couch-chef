using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class ImageService : IImageService
{
    private readonly CouchChefDbContext _context;
    private readonly IStaticFileService _fileService;
    public ImageService(CouchChefDbContext context, IStaticFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<Image> AddImageAsync(PostImageDTO postImageDTO)
    {
        var path = await _fileService.UploadAsync(postImageDTO.Image, false);
        var image = new Image
        {
            Path = path,
            AlternativeText = postImageDTO.AlternativeText
        };
        await _context.AddAsync(image);
        await _context.SaveChangesAsync();
        return image;
    }

    public async Task DeleteImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        _fileService.Remove(image.Path);
        _context.Remove(image);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GetImageDTO>> GetAllAsync()
    {
        var images = await _context.Images.ToListAsync();
        var imageDTOs = images.Select(x => new GetImageDTO
        {
            Id = x.Id,
            AlternativeText = x.AlternativeText,
            Path = x.Path
        }).ToList();
        return imageDTOs;
    }

    public async Task<GetImageDTO> GetImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        var imageDTO = new GetImageDTO
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

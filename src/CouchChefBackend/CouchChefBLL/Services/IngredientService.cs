using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class IngredientService : IIngredientService
{
    private readonly CouchChefDbContext _context;
    private readonly IStaticFileService _staticFileService;
    private readonly IImageService _imageService;
    public IngredientService(CouchChefDbContext context, IStaticFileService staticFileService, IImageService imageService)
    {
        _context = context;
        _staticFileService = staticFileService;
        _imageService = imageService;
    }

    public async Task<PostIngredientDTO> CreateIngredientAsync(PostIngredientDTO postIngredientDTO)
    {
        if (postIngredientDTO.IsImageNotNull())
        {
            string imagePath = "";
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var image = await _imageService.AddImageAsync(postIngredientDTO.PostImageDTO);
                postIngredientDTO.PostImageDTO.Id = image.Id;
                imagePath = image.Path;

                postIngredientDTO.Id = await AddIngredientAsync(postIngredientDTO);

                transaction.Commit();
            }
            catch
            {
                _staticFileService.Remove(imagePath);
                throw;
            }
        }
        else
        {
            postIngredientDTO.Id =  await AddIngredientAsync(postIngredientDTO);
        }
        return postIngredientDTO;
    }

    public async Task DeleteIngredientAsync(int id)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        _context.Remove(ingredient);
        if(ingredient.Image is not null)
            _context.Remove(ingredient.Image);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GetIngredientDTO>> GetAllAsync()
    {
        var ingredients = await _context.Ingredients.ToListAsync();
        var ingredientDTOs = ingredients.Select(x => new GetIngredientDTO
        {
            Id = x.Id,
            Name = x.Name,
            ImageId = x.ImageId,
            Description = x.Description,
            Protein = x.Protein,
            Carbs = x.Carbs,
            Fat = x.Fat,
            Calories = CountCalories(x.Protein, x.Carbs, x.Fat)
        }).ToList();
        return ingredientDTOs;
    }

    public async Task<GetIngredientDTO> GetIngredientAsync(int id)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        var ingredientDTO = new GetIngredientDTO
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            ImageId = ingredient.ImageId,
            Description = ingredient.Description,
            Protein = ingredient.Protein,
            Carbs = ingredient.Carbs,
            Fat = ingredient.Fat,
            Calories = CountCalories(ingredient.Protein, ingredient.Carbs, ingredient.Fat)
        };
        if (ingredient.Image is not null)
        {
            ingredientDTO.GetImageDTO = new GetImageDTO
            {
                Id = ingredient.Image.Id,
                Path = ingredient.Image.Path,
                AlternativeText = ingredient.Image.AlternativeText
            };
        }
        return ingredientDTO;
    }

    public async Task<PostIngredientDTO> UpdateIngredientAsync(int id, PostIngredientDTO postIngredientDTO)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        if (!postIngredientDTO.IsValid())
            throw new ArgumentException("Wrong ingredient nutrition facts");

        ingredient.Name = postIngredientDTO.Name;
        ingredient.Description = postIngredientDTO.Description;
        ingredient.Fat = postIngredientDTO.Fat;
        ingredient.Protein = postIngredientDTO.Protein;
        ingredient.Carbs = postIngredientDTO.Carbs;
        
        if (postIngredientDTO.IsImageNotNull())
        {
            await _staticFileService.UploadAsync(postIngredientDTO.PostImageDTO.Image, false);
            var image =   await _imageService.AddImageAsync(postIngredientDTO.PostImageDTO);
            postIngredientDTO.PostImageDTO.Id = image.Id;

            postIngredientDTO.Id = await AddIngredientAsync(postIngredientDTO);
        }

        _context.Update(ingredient);
        await _context.SaveChangesAsync();
        return postIngredientDTO;
    }

    private float CountCalories(float protein, float carbs, float fat)
    {
        return protein * 4 + carbs * 4 + fat * 9;
    }

    private async Task<Image?> GetImageByIdAsync(int id)
    {
        if (id == -1) return null;
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        return image;
    }

    private async Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        var ingredient = await _context.Ingredients
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (ingredient is null)
            throw new KeyNotFoundException($"Ingredient with id {id} not found.");
        return ingredient;
    }

    private async Task<int> AddIngredientAsync(PostIngredientDTO postIngredientDTO)
    {
        if (!postIngredientDTO.IsValid())
            throw new ArgumentException("Wrong ingredient nutrition facts");

        var ingredient = new Ingredient
        {
            Id = postIngredientDTO.Id,
            Name = postIngredientDTO.Name,
            ImageId = postIngredientDTO.PostImageDTO?.Id,
            Description = postIngredientDTO.Description,
            Protein = postIngredientDTO.Protein,
            Carbs = postIngredientDTO.Carbs,
            Fat = postIngredientDTO.Fat,
        };

        await _context.AddAsync(ingredient);
        await _context.SaveChangesAsync();
        return ingredient.Id;
    }
}

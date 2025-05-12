using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class IngredientService : IIngredientService
{
    private readonly CouchChefDbContext _context;

    public IngredientService(CouchChefDbContext context)
    {
        _context = context;
    }
    public async Task<int> AddIngredientAsync(IngredientDTO ingredientDTO)
    {
        if (!ingredientDTO.IsValid())
            throw new ArgumentException("Wrong ingredient nutrition facts");

        var ingredient = new Ingredient
        {
            Id = ingredientDTO.Id,
            Name = ingredientDTO.Name,
            ImageId = ingredientDTO.ImageId,
            Description = ingredientDTO.Description,
            Protein = ingredientDTO.Protein,
            Carbs = ingredientDTO.Carbs,
            Fat = ingredientDTO.Fat,
        };

        if (ingredientDTO.ImageId is not null)
        {
            var image = await GetImageByIdAsync(ingredientDTO.ImageId ?? -1);
            if (image is null)
                throw new KeyNotFoundException("Image not found");
        }

        await _context.AddAsync(ingredient);
        await _context.SaveChangesAsync();
        return ingredient.Id;
    }

    public async Task DeleteIngredientAsync(int id)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        _context.Remove(ingredient);
        if(ingredient.Image is not null)
            _context.Remove(ingredient.Image);
        await _context.SaveChangesAsync();
    }

    public async Task<List<IngredientDTO>> GetAllAsync()
    {
        var ingredients = await _context.Ingredients.ToListAsync();
        var ingredientDTOs = ingredients.Select(x => new IngredientDTO
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

    public async Task<IngredientDTO> GetIngredientAsync(int id)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        var ingredientDTO = new IngredientDTO
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
            ingredientDTO.ImageDTO = new ImageDTO
            {
                Id = ingredient.Image.Id,
                Path = ingredient.Image.Path,
                AlternativeText = ingredient.Image.AlternativeText
            };
        }
        return ingredientDTO;
    }

    public async Task UpdateIngredientAsync(int id, IngredientDTO ingredientDTO)
    {
        var ingredient = await GetIngredientByIdAsync(id);
        if (!ingredientDTO.IsValid())
            throw new ArgumentException("Wrong ingredient nutrition facts");

        ingredient.Name = ingredientDTO.Name;
        ingredient.Description = ingredientDTO.Description;
        ingredient.Fat = ingredientDTO.Fat;
        ingredient.Protein = ingredientDTO.Protein;
        ingredient.Carbs = ingredientDTO.Carbs;
        ingredient.ImageId = ingredientDTO.ImageId;

        if (ingredientDTO.ImageId is not null)
        {
            var image = await GetImageByIdAsync(ingredientDTO.ImageId ?? -1);
            if (image is null)
                throw new KeyNotFoundException("Image not found");
        }

        _context.Update(ingredient);
        await _context.SaveChangesAsync();        
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
}

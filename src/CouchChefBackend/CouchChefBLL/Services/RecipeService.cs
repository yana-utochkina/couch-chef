using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Interfaces;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefBLL.Services;

public class RecipeService : IRecipeService
{
    private readonly CouchChefDbContext _context;
    public RecipeService(CouchChefDbContext context)
    {
        _context = context;
    }

    public Task<int> AddRecipeAsync(PostRecipeDTO postRecipeDTO)
    {
        //if (!postRecipeDTO.IsValid())
        //    throw new Exception("Recipe isn't valid");
        //var image = await GetImageByIdAsync(postRecipeDTO.ImageId);
        //var cuisine = await GetCuisineByIdAsync(postRecipeDTO.CuisineId);
        //var recipeIngredientDetails = await AddRecipeIngredientDetailsAsync(postRecipeDTO.IngredientIds);
        //var recipeCategories = await AddRecipeCategoriesAsync(postRecipeDTO.CategoryIds);
        //var recipe = new Recipe
        //{
        //    Id = 0,
        //    CuisineId = postRecipeDTO.CuisineId,
        //    Name = postRecipeDTO.Name,
        //    PrepareTime = postRecipeDTO.PrepareTime,
        //    TotalTime = postRecipeDTO.TotalTime,
        //    Servings = postRecipeDTO.Servings,
        //    Directions = postRecipeDTO.Directions,
        //    ImageId = postRecipeDTO.ImageId,
        //    Image = image,
        //    Cuisine = cuisine,
        //    RecipeCategories = recipeCategories,
        //}

        throw new NotImplementedException();
    }

    public Task<GetRecipeDTO> GetRecipeAsync(int id)
    {
        throw new NotImplementedException();
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

    private async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category is null)
        {
            throw new KeyNotFoundException($"Category with id {id} not found.");
        }
        return category;
    }

    private async Task<Cuisine> GetCuisineByIdAsync(int id)
    {
        var cuisine = await _context.Cuisines.FirstOrDefaultAsync(x => x.Id == id);
        if (cuisine is null)
        {
            throw new KeyNotFoundException($"Cuisine with id {id} not found.");
        }
        return cuisine;
    }
}

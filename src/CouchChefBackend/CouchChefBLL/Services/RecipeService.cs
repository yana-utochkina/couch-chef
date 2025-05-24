using CouchChefBLL.DTOs;
using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Filters;
using CouchChefBLL.Interfaces;
using CouchChefBLL.QueryBuilders;
using CouchChefDAL.Data;
using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CouchChefBLL.Services;

public class RecipeService : IRecipeService
{
    private readonly CouchChefDbContext _context;
    private readonly IImageService _imageService;
    private readonly IStaticFileService _staticFileService;
    public RecipeService(CouchChefDbContext context, IImageService imageService, IStaticFileService staticFileService)
    {
        _context = context;
        _imageService = imageService;
        _staticFileService = staticFileService;
    }

    public async Task<PostRecipeDTO> CreateRecipeAsync(PostRecipeDTO postRecipeDTO)
    {
        if (!postRecipeDTO.IsValid())
            throw new Exception("Recipe isn't valid");
        if (!postRecipeDTO.IsImageNotNull())
            throw new Exception("Image should not be null");
        string imagePath = "";
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var image = await _imageService.AddImageAsync(postRecipeDTO.PostImageDTO);
            postRecipeDTO.PostImageDTO.Id = image.Id;
            imagePath = image.Path;

            postRecipeDTO.Id = await AddRecipeAsync(postRecipeDTO, image);
            transaction.Commit();
        }
        catch
        {
            _staticFileService.Remove(imagePath);
            throw;
        }

        return postRecipeDTO;
    }

    public Task<RecipeDTO> GetRecipeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeDTO>> GetRecipesAsync(RecipeFilters filters)
    {
        var baseQuery = _context.Recipes
            .Include(x => x.Image)
            .Include(x => x.Cuisine)
            .Include(x => x.RecipeIngredientDetails)
            .ThenInclude(x => x.Ingredient)
            .Include(x => x.RecipeCategories)
            .ThenInclude(x => x.Category)
            .AsQueryable();

        var queryBuilder = new RecipeQueryBuilder(baseQuery).ApplyFilters(filters);

        var query = queryBuilder.Build();

        await query.ToListAsync();
        
        var recipes = await query.Select(x => new RecipeDTO
        {
            Id = x.Id,
            Name = x.Name,
            PrepareTime = x.PrepareTime,
            TotalTime = x.TotalTime,
            Servings = x.Servings,
            Directions = x.Directions,
            Protein = x.RecipeIngredientDetails.Sum(i => i.Ingredient.Protein / 100),
            Fat = x.RecipeIngredientDetails.Sum(i => i.Ingredient.Fat / 100),
            Carbs = x.RecipeIngredientDetails.Sum(i => i.Ingredient.Carbs / 100),
            Calories = x.RecipeIngredientDetails.Sum(i => i.Ingredient.Protein * 4 + i.Ingredient.Fat * 9 + i.Ingredient.Carbs * 4),
            GetImageDTO = new GetImageDTO
            {
                Id = x.Image.Id,
                Path = x.Image.Path,
                AlternativeText = x.Image.AlternativeText,
            },
            Cuisine = x.Cuisine.Name,
            Categories = x.RecipeCategories.Select(c => c.Category.Name).ToList(),
            Ingredients = x.RecipeIngredientDetails.Select(i => i.Ingredient.Name).ToList()
        }).ToListAsync();

        return recipes;
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

    private async Task<int> AddRecipeAsync(PostRecipeDTO postRecipeDTO, Image image)
    {
        var recipe = new Recipe
        {
            Id = 0,
            CuisineId = postRecipeDTO.CuisineId,
            Name = postRecipeDTO.Name,
            PrepareTime = postRecipeDTO.PrepareTime,
            TotalTime = postRecipeDTO.TotalTime,
            Servings = postRecipeDTO.Servings,
            Directions = postRecipeDTO.Directions,
            ImageId = postRecipeDTO.ImageId,
            Image = image,
            Cuisine = await GetCuisineByIdAsync(postRecipeDTO.CuisineId),
            RecipeCategories = new List<RecipeCategory>(),
            RecipeIngredientDetails = new List<RecipeIngredientDetail>(),
        };
        await _context.AddAsync(recipe);
        await _context.SaveChangesAsync();

        var recipeCategories = await InitRecipeCategoriesAsync(recipe.Id, postRecipeDTO.CategoryIds);
        await _context.AddRangeAsync(recipeCategories);
        await _context.SaveChangesAsync();

        return recipe.Id;
    }

    private async Task<List<RecipeCategory>> InitRecipeCategoriesAsync(int recipeId, List<int> categoryIds)
    {
        var recipeCategory = await _context.Categories
            .Where(x => categoryIds.Contains(x.Id))
            .Select(x => new RecipeCategory 
            { 
                Id = 0,
                RecipeId = recipeId,
                Category = x,
            }).ToListAsync();
        return recipeCategory;
    }

    private async Task<List<RecipeIngredientDetail>> AddRecipeIngredientDetails(int recipeId, List<int> ingredientIds)
    {
        var recipeIngredientDetails = await _context.Ingredients
            .Where(x => ingredientIds.Contains(x.Id))
            .Select(x => new RecipeIngredientDetail
            {
                RecipeId = recipeId,
                IngredientId = x.Id,
                Ingredient = x
            }).ToListAsync();
        return recipeIngredientDetails;
    }
}

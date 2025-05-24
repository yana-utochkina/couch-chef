using CouchChefBLL.DTOs;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Filters;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/recipes")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipeDTO>>> GetRecipes([FromQuery] RecipeFilters filters)
    {
        try
        {
            var recipes = await _recipeService.GetRecipesAsync(filters);
            return Ok(recipes);
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public Task<ActionResult<RecipeDTO>> GetRecipe(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult<PostRecipeDTO>> CreateRecipe([FromForm] PostRecipeDTO postRecipeDTO)
    {
        try
        {
            postRecipeDTO = await _recipeService.CreateRecipeAsync(postRecipeDTO);
            return Ok(postRecipeDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

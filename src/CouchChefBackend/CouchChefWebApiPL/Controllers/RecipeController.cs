using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
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

    [HttpPost]
    public async Task<ActionResult<GetRecipeDTO>> CreateRecipe([FromBody] PostRecipeDTO postRecipeDTO)
    {
        try
        {
            int id = await _recipeService.AddRecipeAsync(postRecipeDTO);
            var getRecipe = await _recipeService.GetRecipeAsync(id);
            return Ok(getRecipe);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

using CouchChefBLL.DTOs;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/ingredients")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<ActionResult<List<IngredientDTO>>> GetAllIngredients()
    {
        try
        {
            var ingredients = await _ingredientService.GetAllAsync();
            return ingredients;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientDTO>> GetIngredient(int id)
    {
        try
        {
            var ingredient = await _ingredientService.GetIngredientAsync(id);
            return Ok(ingredient);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PostIngredientDTO>> AddIngredient([FromForm] PostIngredientDTO postIngredientDTO)
    {
        try
        {
            postIngredientDTO = await _ingredientService.CreateIngredientAsync(postIngredientDTO);
            return Ok(postIngredientDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PostIngredientDTO>> UpdateIngredient(int id, [FromForm] PostIngredientDTO postIngredientDTO)
    {
        try
        {
            var ingredient = await _ingredientService.UpdateIngredientAsync(id, postIngredientDTO);
            return Ok(ingredient);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIngredient(int id)
    {
        try
        {
            await _ingredientService.DeleteIngredientAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

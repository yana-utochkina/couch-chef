using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
    {
        try
        {
            var categoriesDTOs = await _categoryService.GetAllCategoriesAsync();
            return Ok(categoriesDTOs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        try
        {
            var categoryDTO = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            var id = await _categoryService.AddCategoryAsync(categoryDTO);
            categoryDTO = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromQuery] string Name)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(id, Name);
            var categoryDTO = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public async Task<ActionResult<IngredientDTO>> CreateIngredient([FromBody] IngredientDTO ingredientDTO)
        {
            try
            {
                int id = await _ingredientService.AddIngredientAsync(ingredientDTO);
                ingredientDTO = await _ingredientService.GetIngredientAsync(id);
                return Ok(ingredientDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers
{
    [Route("api/cuisines")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService _cuisineService;

        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CuisineDTO>>> GetAllCuisines()
        {
            try
            {
                var cuisines = await _cuisineService.GelAllCuisinesAsync();
                return Ok(cuisines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuisineDTO>> GetCuisine(int id)
        {
            try
            {
                var cuisine = await _cuisineService.GetCuisineAsync(id);
                var cuisineDTO = new CuisineDTO
                {
                    Id = cuisine.Id,
                    Name = cuisine.Name,
                    Description = cuisine.Description
                };
                return Ok(cuisineDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<CuisineDTO>> CreateCuisine([FromBody] CuisineDTO cuisineDTO)
        {
            try
            {
                var id = await _cuisineService.AddCuisineAsync(cuisineDTO);
                cuisineDTO = await _cuisineService.GetCuisineAsync(id);
                return Ok(cuisineDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CuisineDTO>> UpdateCuisine(int id, [FromBody] CuisineDTO cuisineDTO)
        {
            try
            {
                await _cuisineService.UpdateCuisineAsync(id, cuisineDTO);
                cuisineDTO = await _cuisineService.GetCuisineAsync(id);
                return Ok(cuisineDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCuisine(int id)
        {
            try
            {
                await _cuisineService.DeleteCuisineByIdAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

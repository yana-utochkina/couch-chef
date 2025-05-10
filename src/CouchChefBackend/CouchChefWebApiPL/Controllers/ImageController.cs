using CouchChefBLL.DTOs;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImage(int id)
        {
            try
            {
                var imageDTO = await _imageService.GetImageAsync(id);
                return Ok(imageDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ImageDTO>> CreateImage([FromBody] ImageDTO imageDTO)
        {
            try
            {
                int id = await _imageService.AddImageAsync(imageDTO);
                imageDTO = await _imageService.GetImageAsync(id);
                return imageDTO;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateImage(int id, [FromQuery] string alternativeText)
        {
            try
            {
                await _imageService.UpdateImageAsync(id, alternativeText);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            try
            {
                await _imageService.DeleteImageAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

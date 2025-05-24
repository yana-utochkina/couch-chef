using CouchChefBLL.DTOs.Get;
using CouchChefBLL.DTOs.Post;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/images")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetImageDTO>>> GetAllImages()
    {
        try
        {
            var images = await _imageService.GetAllAsync();
            return Ok(images);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetImageDTO>> GetImage(int id)
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

    //[HttpPost]
    //public async Task<ActionResult<ImageDTO>> CreateImage([FromForm] PostImageDTO postImageDTO)
    //{
    //    try
    //    {
    //        postImageDTO = await _imageService.AddImageAsync(postImageDTO);
    //        return postImageDTO;
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

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

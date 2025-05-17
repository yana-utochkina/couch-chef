using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/files")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IStaticFileService _staticFileService;
    public FileController(IStaticFileService staticFileService)
    {
        _staticFileService = staticFileService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> UploadFile(IFormFile file, [FromQuery] bool addCustomGuid)
    {
        try
        {
            string relativePath = await _staticFileService.UploadAsync(file, addCustomGuid);
            return relativePath;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

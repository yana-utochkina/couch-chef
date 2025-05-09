using CouchChefBLL.Interfaces;
using CouchChefDAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/advises")]
[ApiController]
public class AdviseController : ControllerBase
{
    private readonly IAdviseService _adviseService;

    public AdviseController(IAdviseService adviseService)
    {
        _adviseService = adviseService;
    }

    [HttpPost]
    public async Task<ActionResult<Advise>> Post([FromBody] Advise model)
    {
        try
        {
            //var id = await _adviseService.AddAdviseAsync(model);
            //var advise = await _adviseService.GetAdviseAsync(id);
            return Ok(/*advise*/);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Advise model)
    {
        try
        {
            model.Id = id;
            //await _adviseService.UpdateAdviseAsync(model);\
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            //await _adviseService.DeleteAdviseAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

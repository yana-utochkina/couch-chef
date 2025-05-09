using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdviseController : ControllerBase
{
    private readonly IAdviseService _adviseService;

    public AdviseController(IAdviseService adviseService)
    {
        _adviseService = adviseService;
    }
}

using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CouchChefWebApiPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService _cuisineService;

        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }
    }
}

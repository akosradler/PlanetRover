using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController
    {
        [HttpGet]
        public async Task<ActionResult<string>> Index()
        {
            return await Task.FromResult("Your API is running");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {

        [HttpGet]
        [Route("/")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }
    }
}

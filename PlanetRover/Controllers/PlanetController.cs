using Microsoft.AspNetCore.Mvc;
using PlanetRover.DTOs;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<PlanetResponseDto>> Get()
        {
            return Ok(new PlanetResponseDto());
        }
    }
}

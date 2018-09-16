using Microsoft.AspNetCore.Mvc;
using PlanetRover.DTOs;
using PlanetRover.Services;
using PlanetRover.Services.Interfaces;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private IPlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<ActionResult<PlanetResponseDto>> Get()
        {
            return Ok(new PlanetResponseDto() { PlanetSurface = await _planetService.GetPlanetLayout()});
        }
    }
}

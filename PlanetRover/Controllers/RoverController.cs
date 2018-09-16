using Microsoft.AspNetCore.Mvc;
using PlanetRover.DTOs.Request;
using PlanetRover.Services;
using PlanetRover.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private IPlanetService _planetService;
        private IRoverService _roverService;

        public RoverController(PlanetService planetService, RoverService roverService)
        {
            _planetService = planetService;
            _roverService = roverService;
        }

        [HttpPost]
        [Route("land")]
        public async Task<ActionResult<bool>> Land([FromBody]LandRequestDto landDto)
        {
            if (await _planetService.IsValidTile(landDto.Latitude, landDto.Longitude))
            {
                await _roverService.Land(landDto.Latitude, landDto.Longitude);
                return Ok("Rover landed");
            }
            return Ok("The rover cannot land there");
        }
    }
}

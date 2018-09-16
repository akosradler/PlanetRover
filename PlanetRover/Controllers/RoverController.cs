using Microsoft.AspNetCore.Mvc;
using PlanetRover.DTOs.Request;
using PlanetRover.DTOs.Response;
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
        [Route("move")]
        public async Task<ActionResult<MoveResponseDto>> Move([FromBody]MoveRequestDto moveDto)
        {
            if (await _roverService.MoveSequence(moveDto.Path))
            {
                return Ok(new MoveResponseDto { RoverResponse = $"Rover moved successfully. New Position: {_roverService.Position.Item1},{_roverService.Position.Item2} Direction: {_roverService.Compass.ToString()}" });
            }
            return Ok(new MoveResponseDto { RoverResponse = $"Rover encountered an obstacle. New Position: {_roverService.Position.Item1},{_roverService.Position.Item2} Direction: {_roverService.Compass.ToString()}" });
        }

        [HttpPost]
        [Route("land")]
        public async Task<ActionResult<bool>> Land([FromBody]LandRequestDto landDto)
        {
            if (await _planetService.IsValidTile(landDto.Latitude, landDto.Longitude))
            {
                await _roverService.Land(landDto.Latitude, landDto.Longitude);
                return Ok($"Rover has landed at {_roverService.Position.Item1},{_roverService.Position.Item2} facing {_roverService.Compass.ToString()}");
            }
            return Ok("The rover cannot land there");
        }
    }
}

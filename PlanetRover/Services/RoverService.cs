using Microsoft.Extensions.Logging;
using PlanetRover.Models;
using PlanetRover.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class RoverService : IRoverService
    {
        private ILogger _logger;
        private IPlanetService _planetService;
        private Rover _rover;

        protected RoverService()
        {

        }

        public RoverService(ILogger<IRoverService> logger, PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }

        public bool RoverLanded => _rover.Landed;
        public virtual Tuple<int, int> Position => _rover.Position;
        public virtual Compass Compass => _rover.Compass;

        public async Task Land(int latitude, int longitude)
        {
            _rover = new Rover(latitude, longitude);
            await Task.CompletedTask;
        }

        public virtual async Task<bool> MoveSequence(string path)
        {
            throw new NotImplementedException();
        }
    }
}

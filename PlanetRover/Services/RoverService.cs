using Microsoft.Extensions.Logging;
using PlanetRover.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class RoverService : IRoverService
    {
        private ILogger _logger;
        private IPlanetService _planetService;

        protected RoverService()
        {

        }

        public RoverService(ILogger<IRoverService> logger, PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }

        public async Task Land(int latitude, int longitude)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> MoveSequence(string path)
        {
            throw new NotImplementedException();
        }
    }
}

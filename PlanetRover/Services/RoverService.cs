using Microsoft.Extensions.Logging;
using PlanetRover.Services.Interfaces;

namespace PlanetRover.Services
{
    public class RoverService
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
    }
}

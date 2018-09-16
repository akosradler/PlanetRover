using PlanetRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class PlanetService : IPlanetService
    {
        private IPlanetSurfaceService _planetSurfaceService;
        private Lazy<Planet> _planet;

        protected PlanetService()
        {
        }

        public PlanetService(PlanetSurfaceService planetSurfaceService)
        {
            _planetSurfaceService = planetSurfaceService;
            _planet = new Lazy<Planet>(() => new Planet(planetSurfaceService.GetPlanetLayout()));
        }

        public virtual async Task<int[,]> GetPlanetLayout()
        {
            return await Task.FromResult(_planet.Value.PlanetLayout);
        }

        public virtual async Task<int> GetPlanetSize()
        {
            return await Task.FromResult(_planet.Value.PlanetSize);
        }

        public virtual async Task<bool> IsValidTile(int latitude, int longitude)
        {
            var outOfBounds = latitude < 0 || longitude < 0 || latitude >= _planet.Value.PlanetSize - 1 || longitude >= _planet.Value.PlanetSize - 1;
            var isValid = !outOfBounds && _planet.Value.PlanetLayout[latitude, longitude] == (int)Surface.Empty;
            return await Task.FromResult(isValid);
        }
    }
}

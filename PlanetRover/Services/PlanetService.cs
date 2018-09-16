using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class PlanetService : IPlanetService
    {
        public PlanetService()
        {
        }

        public virtual async Task<int[,]> GetPlanetLayout()
        {
            return await Task.FromResult(new int[,] { { 0, 0 }, { 0, 0 } });
        }

        public virtual async Task<bool> IsValidTile(int latitude, int longitude)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class PlanetService : IPlanetService
    {
        protected PlanetService()
        {
        }

        public virtual async Task<int[,]> GetPlanetLayout()
        {
            return await Task.FromResult(new int[,] { { 0, 0 }, { 0, 0 } });
        }
    }
}

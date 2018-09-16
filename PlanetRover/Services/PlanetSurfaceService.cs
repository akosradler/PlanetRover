using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class PlanetSurfaceService : IPlanetSurfaceService
    {
        public virtual int[,] GetPlanetLayout()
        {
            return new int[10, 10]
            {
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,1,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,1,0,0,0,0 },
                { 0,0,0,1,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
                { 0,1,0,0,0,1,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0 },
            };
        }
    }
}

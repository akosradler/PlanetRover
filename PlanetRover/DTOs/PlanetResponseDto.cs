using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.DTOs
{
    public class PlanetResponseDto
    {
        public class PlanetSurfaceResponseDto
        {
            public int[,] PlanetSurface { get; set; }
        }
    }
}

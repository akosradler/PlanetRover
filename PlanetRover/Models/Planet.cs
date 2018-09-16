using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Models
{
    public class Planet
    {
        public Planet(int[,] planetLayout)
        {
            PlanetLayout = planetLayout;
        }

        public int[,] PlanetLayout { get; set; }

        public int PlanetSize => PlanetLayout.Length;
    }
}

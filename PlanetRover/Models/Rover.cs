using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Models
{
    public class Rover
    {
        public Rover(int latitude, int longitude)
        {
            Position = new Tuple<int, int>(latitude, longitude);
            Compass = Compass.S;
            Landed = true;
        }

        public Tuple<int, int> Position { get; set; }

        public Compass Compass { get; set; }

        public bool Landed { get; set; }
    }
}

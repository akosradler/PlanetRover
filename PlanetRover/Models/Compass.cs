using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Models
{
    public enum Compass
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public static class CompassExtensions
    {
        public static Compass Invert(this Compass compass)
        {
            switch (compass)
            {
                case Compass.N:
                    return Compass.S;
                case Compass.E:
                    return Compass.W;
                case Compass.S:
                    return Compass.N;
                case Compass.W:
                    return Compass.E;
            }
            return compass;
        }

        public static Compass TurnRight(this Compass compass)
        {
            switch (compass)
            {
                case Compass.N:
                    return Compass.E;
                case Compass.E:
                    return Compass.S;
                case Compass.S:
                    return Compass.W;
                case Compass.W:
                    return Compass.N;
            }
            return compass;
        }

        public static Compass TurnLeft(this Compass compass)
        {
            switch (compass)
            {
                case Compass.N:
                    return Compass.W;
                case Compass.E:
                    return Compass.N;
                case Compass.S:
                    return Compass.E;
                case Compass.W:
                    return Compass.S;
            }
            return compass;
        }
    }
}

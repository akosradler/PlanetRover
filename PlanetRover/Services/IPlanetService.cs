using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public interface IPlanetService
    {
        Task<int[,]> GetPlanetLayout();
    }
}

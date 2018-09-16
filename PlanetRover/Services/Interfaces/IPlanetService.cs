using System.Threading.Tasks;

namespace PlanetRover.Services.Interfaces
{
    public interface IPlanetService
    {
        Task<int[,]> GetPlanetLayout();
    }
}

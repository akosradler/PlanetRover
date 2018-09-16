using System.Threading.Tasks;

namespace PlanetRover.Services.Interfaces
{
    public interface IPlanetService
    {
        Task<int[,]> GetPlanetLayout();
        Task<int> GetPlanetSize();
        Task<bool> IsValidTile(int latitude, int longitude);
    }
}

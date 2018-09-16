using System.Threading.Tasks;

namespace PlanetRover.Services.Interfaces
{
    public interface IRoverService
    {
        Task Land(int latitude, int longitude);
        Task<bool> MoveSequence(string path);
    }
}

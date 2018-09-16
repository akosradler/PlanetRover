using Microsoft.Extensions.Logging;
using PlanetRover.Models;
using PlanetRover.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlanetRover.Services
{
    public class RoverService : IRoverService
    {
        private ILogger _logger;
        private IPlanetService _planetService;
        private Rover _rover;

        protected RoverService()
        {

        }

        public RoverService(ILogger<IRoverService> logger, PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }

        public bool RoverLanded => _rover.Landed;
        public virtual Tuple<int, int> Position => _rover.Position;
        public virtual Compass Compass => _rover.Compass;

        public async Task Land(int latitude, int longitude)
        {
            _rover = new Rover(latitude, longitude);
            await Task.CompletedTask;
        }

        public virtual async Task<bool> MoveSequence(string path)
        {
            foreach (var direction in path)
            {
                switch (direction)
                {
                    case 'F':
                        if (!await Move(NextTile(_rover.Position, _rover.Compass)))
                        {
                            _logger.LogTrace($"Rover failed to move. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                            return false;
                        }
                        _logger.LogTrace($"Rover moved. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                        break;
                    case 'B':
                        if (!await Move(NextTile(_rover.Position, _rover.Compass.Invert())))
                        {
                            _logger.LogTrace($"Rover failed to move. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                            return false;
                        }
                        _logger.LogTrace($"Rover moved. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                        break;
                    case 'L':
                        _rover.Compass = _rover.Compass.TurnLeft();
                        _logger.LogTrace($"Rover turned left. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                        break;
                    case 'R':
                        _rover.Compass = _rover.Compass.TurnRight();
                        _logger.LogTrace($"Rover turned right. Position: {_rover.Position.Item1},{_rover.Position.Item2} Direction: {_rover.Compass.ToString()}");
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }

        private async Task<bool> Move(Tuple<int, int> nextTile)
        {
            if (await _planetService.IsValidTile(nextTile.Item1, nextTile.Item2))
            {
                _rover.Position = nextTile;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Tuple<int, int> NextTile(Tuple<int, int> currentTile, Compass compass)
        {
            switch (compass)
            {
                case Compass.N:
                    return new Tuple<int, int>(currentTile.Item1, currentTile.Item2 - 1);
                case Compass.E:
                    return new Tuple<int, int>(currentTile.Item1 + 1, currentTile.Item2);
                case Compass.S:
                    return new Tuple<int, int>(currentTile.Item1, currentTile.Item2 + 1);
                case Compass.W:
                    return new Tuple<int, int>(currentTile.Item1 - 1, currentTile.Item2);
                default:
                    return currentTile;
            }
        }
    }
}

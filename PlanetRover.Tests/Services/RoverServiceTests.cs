using Microsoft.Extensions.Logging;
using Moq;
using PlanetRover.Services;
using System.Threading.Tasks;
using Xunit;

namespace PlanetRover.Tests.Services
{
    public class RoverServiceTests
    {
        private ILogger<RoverService> _loggerMock;

        public RoverServiceTests()
        {
            _loggerMock = (new Mock<ILogger<RoverService>>()).Object;
        }

        [Fact]
        public async Task MoveSequence_MovesForward_MoveSequenceF()
        {
            //Arrange
            var fileReaderServiceMock = new Mock<PlanetSurfaceService>();
            fileReaderServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[2, 2] { { 0, 0 }, { 0, 0 } });
            var planetService = new PlanetService(fileReaderServiceMock.Object);

            var roverService = new RoverService(_loggerMock, planetService);

            await roverService.Land(0, 0);

            //Act

            await roverService.MoveSequence("F");

            //Assert

            Assert.True(roverService.Position.Item1 == 0 && roverService.Position.Item2 == 1);
        }

        [Fact]
        public async Task MoveSequence_MovesBackward_MoveSequenceS()
        {
            //Arrange
            var fileReaderServiceMock = new Mock<PlanetSurfaceService>();
            fileReaderServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[2, 2] { { 0, 0 }, { 0, 0 } });
            var planetService = new PlanetService(fileReaderServiceMock.Object);

            var roverService = new RoverService(_loggerMock, planetService);

            await roverService.Land(0, 1);

            //Act

            await roverService.MoveSequence("B");

            //Assert

            Assert.True(roverService.Position.Item1 == 0 && roverService.Position.Item2 == 0);
        }

        [Fact]
        public async Task MoveSequence_FacesEast_MoveSequenceR()
        {
            //Arrange
            var fileReaderServiceMock = new Mock<PlanetSurfaceService>();
            fileReaderServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[2, 2] { { 0, 0 }, { 0, 0 } });
            var planetService = new PlanetService(fileReaderServiceMock.Object);

            var roverService = new RoverService(_loggerMock, planetService);

            await roverService.Land(0, 0);

            //Act

            await roverService.MoveSequence("R");

            //Assert

            Assert.True(roverService.Compass == Models.Compass.W);
        }

        [Fact]
        public async Task MoveSequence_FacesWest_MoveSequenceL()
        {
            //Arrange
            var fileReaderServiceMock = new Mock<PlanetSurfaceService>();
            fileReaderServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[2, 2] { { 0, 0 }, { 0, 0 } });
            var planetService = new PlanetService(fileReaderServiceMock.Object);

            var roverService = new RoverService(_loggerMock, planetService);

            await roverService.Land(0, 0);

            //Act

            await roverService.MoveSequence("L");

            //Assert

            Assert.True(roverService.Compass == Models.Compass.E);
        }

        [Fact]
        public async Task MoveSequence_HitsObsacle_MoveSuccessUntilHit()
        {
            //Arrange
            var fileReaderServiceMock = new Mock<PlanetSurfaceService>();
            fileReaderServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[3, 3] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var planetService = new PlanetService(fileReaderServiceMock.Object);

            var roverService = new RoverService(_loggerMock, planetService);

            await roverService.Land(0, 0);

            //Act

            await roverService.MoveSequence("FLFF");

            //Assert

            Assert.True(roverService.Position.Item1 == 0 && roverService.Position.Item2 == 1);
        }
    }
}

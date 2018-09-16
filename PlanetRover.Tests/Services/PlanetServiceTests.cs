using Moq;
using PlanetRover.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlanetRover.Tests.Services
{
    public class PlanetServiceTests
    {
        [Fact]
        public async Task IsValidTile_ReturnsFalse_OutsideOfBonds()
        {
            //Arrange
            var planetSurfaceServiceMock = new Mock<PlanetSurfaceService>();
            planetSurfaceServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[1, 1] { { 0 } });
            var planetService = new PlanetService(planetSurfaceServiceMock.Object);

            //Act
            //Assert
            Assert.False(await planetService.IsValidTile(1, 1));
        }

        [Fact]
        public async Task IsValidTile_ReturnsFalse_OnObstacle()
        {
            //Arrange
            var planetSurfaceServiceMock = new Mock<PlanetSurfaceService>();
            planetSurfaceServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[1, 1] { { 1 } });
            var planetService = new PlanetService(planetSurfaceServiceMock.Object);

            //Act
            //Assert
            Assert.False(await planetService.IsValidTile(0, 0));
        }

        [Fact]
        public async Task IsValidTile_ReturnsTrue_LandingOnValidTile()
        {
            //Arrange
            var planetSurfaceServiceMock = new Mock<PlanetSurfaceService>();
            planetSurfaceServiceMock.Setup(service => service.GetPlanetLayout()).Returns(() => new int[1, 1] { { 0 } });
            var planetService = new PlanetService(planetSurfaceServiceMock.Object);

            //Act
            //Assert
            Assert.True(await planetService.IsValidTile(0, 0));
        }
    }
}

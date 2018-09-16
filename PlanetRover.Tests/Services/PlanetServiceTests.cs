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
            var planetService = new PlanetService();

            //Act
            //Assert
            Assert.False(await planetService.IsValidTile(1, 1));
        }

        [Fact]
        public async Task IsValidTile_ReturnsFalse_OnObstacle()
        {
            //Arrange
            var planetService = new PlanetService();

            //Act
            //Assert
            Assert.False(await planetService.IsValidTile(0, 0));
        }

        [Fact]
        public async Task IsValidTile_ReturnsTrue_LandingOnValidTile()
        {
            //Arrange
            var planetService = new PlanetService();

            //Act
            //Assert
            Assert.True(await planetService.IsValidTile(0, 0));
        }
    }
}

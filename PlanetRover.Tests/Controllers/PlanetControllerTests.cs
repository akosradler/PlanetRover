using Microsoft.AspNetCore.Mvc;
using Moq;
using PlanetRover.Controllers;
using PlanetRover.Services;
using System.Threading.Tasks;
using Xunit;

namespace PlanetRover.Tests.Controllers
{
    public class PlanetControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOK_WhenRequested()
        {
            //Arrange
            var planetServiceMock = new Mock<PlanetService>();
            planetServiceMock.Setup(service => service.GetPlanetLayout()).Returns(Task.FromResult(new int[1, 1]));
            var planetController = new PlanetController(planetServiceMock.Object);

            //Act
            var response = await planetController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }

  
    }
}

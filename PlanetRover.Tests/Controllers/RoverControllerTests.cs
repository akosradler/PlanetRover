using Microsoft.AspNetCore.Mvc;
using Moq;
using PlanetRover.Controllers;
using PlanetRover.DTOs.Request;
using PlanetRover.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlanetRover.Tests.Controllers
{
    public class RoverControllerTests
    {
        [Fact]
        public async Task Land_ReturnsOK_WhenPosted()
        {
            //Arrange
            var roverServiceMock = new Mock<RoverService>();
            roverServiceMock.Setup(service => service.Position).Returns(new Tuple<int, int>(0, 0));
            roverServiceMock.Setup(service => service.Compass).Returns(Models.Compass.N);
            var planetServiceMock = new Mock<PlanetService>();
            planetServiceMock.Setup(service => service.IsValidTile(0, 0)).Returns(Task.FromResult(true));
            var roverController = new RoverController(planetServiceMock.Object, roverServiceMock.Object);

            //Act
            var response = await roverController.Land(new LandRequestDto { Latitude = 0, Longitude = 0 });

            //Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task Move_ReturnsOK_WhenPosted()
        {
            //Arrange
            var roverServiceMock = new Mock<RoverService>();
            var planetServiceMock = new Mock<PlanetService>();
            roverServiceMock.Setup(service => service.MoveSequence("F")).Returns(Task.FromResult(true));
            roverServiceMock.Setup(service => service.Position).Returns(new Tuple<int, int>(0, 0));
            roverServiceMock.Setup(service => service.Compass).Returns(Models.Compass.N);
            var roverController = new RoverController(planetServiceMock.Object, roverServiceMock.Object);

            //Act
            var response = await roverController.Move(new MoveRequestDto { Path = "F" });

            //Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }
    }
}

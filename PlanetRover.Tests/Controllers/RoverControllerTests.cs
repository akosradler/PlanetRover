using Microsoft.AspNetCore.Mvc;
using PlanetRover.Controllers;
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
            var roverController = new RoverController();

            //Act
            var response = await roverController.Land();

            //Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }
    }
}

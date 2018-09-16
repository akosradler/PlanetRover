using Microsoft.AspNetCore.Mvc;
using PlanetRover.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
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
            var planetController = new PlanetController();

            //Act
            var response = await planetController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }
    }
}

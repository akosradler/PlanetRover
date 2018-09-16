using Microsoft.Extensions.Logging;
using Moq;
using PlanetRover.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetRover.Tests.Services
{
    public class RoverServiceTests
    {
        private ILogger<RoverService> _loggerMock;

        public RoverServiceTests()
        {
            _loggerMock = (new Mock<ILogger<RoverService>>()).Object;
        }


    }
}

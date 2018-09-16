using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        [HttpPost]
        [Route("land")]
        public async Task<ActionResult<bool>> Land()
        {
            throw new NotImplementedException();
        }
    }
}

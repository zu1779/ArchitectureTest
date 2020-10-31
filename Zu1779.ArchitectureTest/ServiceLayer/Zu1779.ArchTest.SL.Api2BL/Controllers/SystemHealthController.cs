namespace Zu1779.ArchTest.SL.Api2BL.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class SystemHealthController : ControllerBase
    {
        private readonly ILogger<SystemHealthController> log;

        public SystemHealthController(ILogger<SystemHealthController> log)
        {
            this.log = log;
        }
        private readonly Random rng = new Random();

        [HttpGet("systemload")]
        public int GetSystemLoad()
        {
            var load = rng.Next(100_000);
            log.LogInformation($"System returned a load level = {load}");
            return load;
        }

        [HttpGet("cpunumber")]
        public int GetCpuNumber()
        {
            return 4;
        }
    }
}

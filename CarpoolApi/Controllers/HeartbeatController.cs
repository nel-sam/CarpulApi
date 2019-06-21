using CarpoolApi.Common.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarpoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        private readonly ICustomLogger _logger;

        public HeartbeatController(ICustomLogger logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            _logger.Info(new Dictionary<string, object>
            {
                { "Controller", nameof(HeartbeatController) },
                { "Result", "Alive" }
            });

            return "Alive";
        }
    }
}
using CarpoolApi.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApi.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticateService authService;

        public AuthController(IAuthenticateService authService) => this.authService = authService;

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Get(AuthenticationRequest authenticationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokenResponse = authService.GetToken(authenticationRequest);

            if (tokenResponse == null)
            {
                return Unauthorized("Invalid Request");
            }

            return Ok(tokenResponse);
        }
       
    }
}
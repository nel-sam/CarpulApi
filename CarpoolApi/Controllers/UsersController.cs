using CarpoolApi.Api.Hashing;
using CarpoolApi.Service.DataTransferObjects;
using CarpoolApi.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApi.Api.Properties.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IHashingService _hashingService;

        public UsersController(IUserService userService, IHashingService hashingService)
        {
            _userService = userService;
            _hashingService = hashingService;
        }

        [HttpGet]
        [Route("email")]
        public IActionResult Get([FromQuery] string email)
        {
            var user = User.Identity.Name;

            if (!user.Equals(email))
                return Unauthorized();

            return _userService.GetUser(email) == null ? NotFound() : (IActionResult)Ok(_userService.GetUser(email));
        }


        // POST api/<controller>
		[AllowAnonymous]
        [HttpPost]
        [Route("createprofile")]
        public IActionResult CreateProfile([FromBody] ProfileDto profileDto)
        {
			string msg = null;

			if (!profileDto.IsValid(ref msg))
				return BadRequest(msg);

            byte[] hashedPassword = _hashingService.Encrypt(profileDto.Password);
            _userService.CreateUser(profileDto, hashedPassword);

            return Ok("Profile created.");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

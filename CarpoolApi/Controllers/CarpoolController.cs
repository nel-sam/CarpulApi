using CarpoolApi.Service.DataTransferObjects;
using CarpoolApi.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolApi.Api.Properties.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("api/[controller]")]
    [ApiController]
    public class CarpoolController : ControllerBase
    {
        private ICarpoolService _carpoolService;

        public CarpoolController(ICarpoolService carpoolService)
        {
            _carpoolService = carpoolService;
        }

        // GET: api/Carpool
        // Lookup carpool by ID
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_carpoolService.GetAllCarpools());
        }

        // GET: api/Carpool
        // Lookup carpool by ID
        [HttpGet]
        [Route("id")]
        public IActionResult Get([FromQuery]int id)
        {
            var carpoolDetails = _carpoolService.GetCarpoolById(id);
            return carpoolDetails == null ? NotFound() : (IActionResult)Ok(carpoolDetails);
        }

        //Lookup carpool by zipcode
        [HttpGet]
        [Route("zip")]
        public IActionResult Get([FromQuery]string zipcode)
        {
            var carpoolDetails = _carpoolService.GetCarpoolsByZipcode(zipcode);
            return carpoolDetails == null ? NotFound() : (IActionResult)Ok(carpoolDetails);
        }

        // POST: api/Carpool
        [HttpPost]
        [Route("actionrequest")]
        public void Post([FromBody] RequestDto request)
        {
            _carpoolService.ActionRequest(request, User.Identity.Name);
        }

		[HttpPost]
		[Route("createcarpool")]
		public IActionResult Post([FromBody] CarpoolCreationRequestDto carpool)
		{
            var user = User.Identity.Name;

            if (!user.Equals(carpool.UserEmail, StringComparison.InvariantCultureIgnoreCase))
                return Unauthorized();

            // Do some basic input sanitization
            carpool.Address.State = carpool.Address.State.ToUpper();

            if (!Int32.TryParse(carpool.Address.ZipCode, out var test))
                throw new ArgumentException("Only US zipcodes are supported, which are always numbers", "ZipCode");
                       
            return Ok(_carpoolService.CreateCarpool(carpool));
		}

        [HttpPut("leave/{id}")]
        public IActionResult Leave(int id)
        {
            var user = User.Identity.Name;
            var carpool = _carpoolService.GetCarpoolById(id);

            // Make sure the carpool is not the owner (we don't want to accidentally orphan a carpool
            if (user.Equals(carpool.Owner.Email, StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentException("The owner cannot 'Leave' a carpool");

                // Make sure the user is an actual member of the carpool
                var memberObj = carpool.Members.FirstOrDefault(m => m.Email.Equals(user, StringComparison.InvariantCultureIgnoreCase));

            if (memberObj == null)
                return Unauthorized("The user is not a member of the carpool");

            _carpoolService.LeaveCarpool(id, user);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = User.Identity.Name;
            var carpool = _carpoolService.GetCarpoolById(id);

            if (!user.Equals(carpool.Owner.Email, StringComparison.InvariantCultureIgnoreCase))
                return Unauthorized();

            _carpoolService.DeleteCarpool(id, user);
            return Ok();
        }
    }
}

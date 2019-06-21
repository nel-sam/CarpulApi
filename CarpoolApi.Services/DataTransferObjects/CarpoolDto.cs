using CarpoolApi.Domain.Models;
using System;
using System.Collections.Generic;

namespace CarpoolApi.Service.DataTransferObjects
{
    public class CarpoolDto
    {
        public int Id { get; set; }
        public Address Destination { get; set; }
        public string Incentive { get; set; }
		public string Campus { get; set; }
		public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
		public UserDto Owner { get; set; }
		public List<UserDto> Members { get; set; }
    }
}

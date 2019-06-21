using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public List<UserPhone> UserPhoneNumbers { get; set; }
    }
}

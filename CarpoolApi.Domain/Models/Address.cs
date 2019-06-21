using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public List<Organization> Organizations { get; set; }
        //public List<Campus> Campuses { get; set; }
    }
}

using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Name { get; set; }
        public List<OrganizationCampus> OrganizationCampuses { get; set; }

    }
}

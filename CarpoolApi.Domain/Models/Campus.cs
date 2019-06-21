using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CampusTypeCampus> CampusTypeCampuses { get; set; }
        public List<OrganizationCampus> OrganizationCampuses { get; set; }
        public Address Address { get; set; }
    }
}

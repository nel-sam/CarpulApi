namespace CarpoolApi.Domain.Models
{
    public class OrganizationCampus
    {
        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization{ get; set; }
    }
}

namespace CarpoolApi.Domain.Models
{
    public class CampusTypeCampus
    {
        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public int CampusTypeId { get; set; }
        public CampusType CampusType { get; set; }
    }
}

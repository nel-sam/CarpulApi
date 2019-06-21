using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class CampusType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<CampusTypeCampus> CampusTypeCampuses { get; set; }
    }
}

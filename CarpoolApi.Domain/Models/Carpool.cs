using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class Carpool
    {
        public int Id { get; set; }
        public List<Car> Cars { get; set; }
        public List<Request> Requests { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<User> Users { get; set; }
        public Campus Campus { get; set; }
    }
}

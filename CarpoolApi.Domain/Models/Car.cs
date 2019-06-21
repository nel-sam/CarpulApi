using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlateNo { get; set; }
        public List<UserCar> UserCars { get; set; }
        public Carpool Carpool { get; set; }

    }
}

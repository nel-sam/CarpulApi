using System.Collections.Generic;

namespace CarpoolApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Carpool Carpool { get; set; }
        public List<UserCar> UserCars { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserPhone> UserPhones { get; set; }
        public List<Request> Requests { get; set; }
        public Address Address { get; set; }
        public UserType UserType { get; set; }
    }
}

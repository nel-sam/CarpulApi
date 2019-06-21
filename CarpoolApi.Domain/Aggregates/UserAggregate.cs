using CarpoolApi.Domain.Models;
using System.Collections.Generic;

namespace CarpoolApi.Domain.Aggregates
{
    public class UserAggregate
    {
        public UserAggregate()
        {
            PhoneNumbers = new List<PhoneNumber>();
            Cars = new List<Car>();
			InboundRequests = new List<Request>();
			OutboundRequests = new List<Request>();

		}

        public User User { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public UserType UserType { get; set; }
        public Address Address { get; set; }
        public List<Car> Cars { get; set; }
        public Carpool Carpool { get; set; }
        public List<Request> InboundRequests { get; set; }
        public List<Request> OutboundRequests { get; set; }

        public void addPhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumbers.Add(phoneNumber);
        }
        public void addCar(Car car)
        {
            Cars.Add(car);
        }

		public void addInboundRequest(Request request)
		{
			InboundRequests.Add(request);
		}

		public void addOutboundRequest(Request request)
		{
			OutboundRequests.Add(request);
		}

		public void mapUser(string firstName, string lastName, string email, string password)
        {
            User = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };                
        }

		public void mapAddress(string street, string city, string state, string zipCode)
		{
			Address = new Address
			{
				StreetNumber = street,
				City = city,
				State = state,
				ZipCode = zipCode
			};
		}

    }
}

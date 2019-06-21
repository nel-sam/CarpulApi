using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Infastructure;
using System;
using System.Linq;

namespace CarpoolApi.Infrastructure.SQLRepositories
{
    public class AddressDetails : IAddressDetails
    {
        private DatabaseContext _dbContext;

        public AddressDetails(DatabaseContext context) => _dbContext = context;

        public Address Get(string streetNumber, string city, string state, string zipcode)
        {
            return _dbContext.Addresses.FirstOrDefault(a => 
                a.StreetNumber.Equals(streetNumber, StringComparison.InvariantCultureIgnoreCase)
                && a.ZipCode.Equals(zipcode, StringComparison.InvariantCultureIgnoreCase)
                && a.State.Equals(state, StringComparison.InvariantCultureIgnoreCase)
                && a.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));
        }

        public void Add(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
        }
    }
}

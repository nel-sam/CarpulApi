using CarpoolApi.Domain.Models;

namespace CarpoolApi.Domain.Repositories
{
    public interface IAddressDetails
    {
        Address Get(string streetNumber, string city, string state, string zipcode);
        void Add(Address address);
    }
}

using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Models;

namespace CarpoolApi.Domain.Repositories
{
    public interface IUserDetails
    {
        void Update(User user);
        void Add(UserAggregate user);
        User GetUserModel(string email);
        UserAggregate GetUser(string email);
        UserType GetUserType(string description);
        
    }
}

using CarpoolApi.Domain.Repositories;

namespace CarpoolApi.Api.Authentication
{
    public class UserManagementService : IUserManagementService
    {
        private IUserDetails userDetails;

        public UserManagementService(IUserDetails userDetails) => this.userDetails = userDetails;

        public bool IsValidUser(string userName, string password)
        {
            var user = userDetails.GetUserModel(userName);

            // TODO: Yes, it is very unsafe to store passwords in a database.
            // In production, we would have some hashing here (with salt). Implement 
            // that once time allows
            if (user == null || !user.Password.Equals(password))
                return false;

            return true;
        }

    }
}

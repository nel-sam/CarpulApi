using CarpoolApi.Api.Hashing;
using CarpoolApi.Domain.Repositories;

namespace CarpoolApi.Api.Authentication
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserDetails userDetails;
        private readonly IHashingService hashingService;

        public UserManagementService(IUserDetails userDetails, IHashingService hashingService)
        {
            this.userDetails = userDetails;
            this.hashingService = hashingService;
        }

        public bool IsValidUser(string userName, string plainTextPassword)
        {
            try
            {
                var user = userDetails.GetUserModel(userName);
                var decrypted = hashingService.Decrypt(user.Password, plainTextPassword);

                if (user != null && decrypted.Equals(plainTextPassword))
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

    }
}

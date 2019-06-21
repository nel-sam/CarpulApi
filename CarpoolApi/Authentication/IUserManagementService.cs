namespace CarpoolApi.Api.Authentication
{
    public interface IUserManagementService
    {
        bool IsValidUser(string username, string password);
    }
}

using CarpoolApi.Service.DataTransferObjects;

namespace CarpoolApi.Service.Services
{
    public interface IUserService
    {
        UserDto GetUser(string email);
        void CreateUser(ProfileDto profileDto, byte[] hashedPassword);
    }
}

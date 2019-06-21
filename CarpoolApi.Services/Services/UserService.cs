using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Enums;
using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Service;
using CarpoolApi.Service.DataTransferObjects;
using CarpoolApi.Service.Services;

namespace CarpoolApi.Services
{
    public class UserService : IUserService
    {
        private IUserDetails _userDetails;

        public UserService(IUserDetails userDetails) => _userDetails = userDetails;

        public UserDto GetUser(string email)
        {
            var model = _userDetails.GetUser(email);
            return BuildUserDtoBy(model);
        }

        private UserDto BuildUserDtoBy(UserAggregate userAggregate)
        {
            if (userAggregate == null)
                return null;

            UserDto user = new UserDto(userAggregate);

            userAggregate.PhoneNumbers.ForEach(p => user.AddPhoneNumber(p.AreaCode + p.Number));

            userAggregate.Cars.ForEach(c => user.AddCarDto(c.Make, c.Model, c.Year, c.Color, c.LicensePlateNo));

            if (user.UserType == "Carpool Owner")
            {
				foreach (Request request in userAggregate.InboundRequests)
				{
					if (request.Approval != (int)Enums.Status.Deleted)
					{
						user.AddInboundRequest(request.User.FirstName, request.User.LastName, request.Message, request.Approval, request.Carpool.Id);
					}
				}
            }
            else
            {
				foreach (Request request in userAggregate.OutboundRequests)
				{
					if (request.Approval != (int)Enums.Status.Deleted)
					{
						user.AddOutboundRequest(request.User.FirstName, request.User.LastName, request.Message, request.Approval, request.Carpool.Id);
					}
				}
            }

            if (userAggregate.Carpool != null) { user.CarpoolId = userAggregate.Carpool.Id; }

            return user;
        }

        public void CreateUser(ProfileDto profileDto)
        {
            UserAggregate userAggregate = new UserAggregate();
            userAggregate.mapUser(profileDto.FirstName, profileDto.LastName, profileDto.Email, profileDto.Password);
			userAggregate.mapAddress(profileDto.Address.StreetNumber, profileDto.Address.City, profileDto.Address.State, profileDto.Address.ZipCode);

            userAggregate.addPhoneNumber(
                    new PhoneNumber
                    {
                        AreaCode = profileDto.AreaCode,
                        Number = profileDto.PhoneNumber
                    }
                );

            _userDetails.Add(userAggregate);
        }
    }
}

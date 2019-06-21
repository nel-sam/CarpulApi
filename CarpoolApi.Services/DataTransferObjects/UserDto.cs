using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Enums;
using CarpoolApi.Service.DataTransferObjects;
using System.Collections.Generic;

namespace CarpoolApi.Service
{
    public class UserDto
    {
		//Generic constructor for serialization
		public UserDto() { }

		public UserDto(UserAggregate userAggregate)
        {
            Cars = new List<CarDto>();
            Email = userAggregate.Email;
            PhoneNumber = new List<string>();
            LastName = userAggregate.User.LastName;
            UserType = userAggregate.UserType.Type;
            FirstName = userAggregate.User.FirstName;
            InboundRequests = new List<RequestDto>();
            OutboundRequests = new List<RequestDto>();
            Address = new AddressDto
            {
                StreetNumber = userAggregate.Address.StreetNumber,
                ZipCode = userAggregate.Address.ZipCode,
                State = userAggregate.Address.State,
                City = userAggregate.Address.City,
            };
        }

        public string Email { get; set; }
        public int CarpoolId { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public List<CarDto> Cars { get; set; }
        public AddressDto Address { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<RequestDto> InboundRequests { get; set; }
        public List<RequestDto> OutboundRequests { get; set; }

        public void AddCarDto(string make, string model, int year, string color, string licensePlate)
        {
            Cars.Add(new CarDto(make, model, year, color, licensePlate));
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            PhoneNumber.Add(phoneNumber);
        }

        public void AddInboundRequest(string firstName, string lastName, string message, int approval, int carpoolId)
        {
            InboundRequests.Add(new RequestDto(firstName, lastName, message, GetRequestApprovalStatus(approval), null, carpoolId));
        }

        public void AddOutboundRequest(string firstName, string lastName, string message, int approval, int carpoolId)
        {
            OutboundRequests.Add(new RequestDto(firstName, lastName, message, GetRequestApprovalStatus(approval), null, carpoolId));
        }

        public string GetRequestApprovalStatus(int approval)
        {
            string status = null;

            switch (approval)
            {
                case (int)Enums.Status.Pending:
                    status = Enums.Status.Pending.ToString();
                    break;
                case (int)Enums.Status.Approved:
                    status = Enums.Status.Approved.ToString();
                    break;
                case (int)Enums.Status.Rejected:
                    status = Enums.Status.Rejected.ToString();
                    break;
            }

            return status;
        }
    }
}

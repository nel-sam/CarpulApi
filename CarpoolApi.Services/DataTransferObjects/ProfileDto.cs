using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolApi.Service.DataTransferObjects
{
    public class ProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
		public AddressDto Address { get; set; }

		public bool IsValid(ref string msg)
		{
			if (String.IsNullOrEmpty(FirstName))
			{
				msg = ErrorMessages.MissingFirstName;
				return false;
			}
			else if (String.IsNullOrEmpty(LastName))
			{
				msg = ErrorMessages.MissingLastName;
				return false;
			}
			else if (String.IsNullOrEmpty(Email))
			{
				msg = ErrorMessages.MissingEmail;
				return false;
			}
			else if (String.IsNullOrEmpty(Password))
			{
				msg = ErrorMessages.MissingPassword;
				return false;
			}
			else if (String.IsNullOrEmpty(AreaCode))
			{
				msg = ErrorMessages.MissingAreaCode;
				return false;
			}
			else if (String.IsNullOrEmpty(PhoneNumber))
			{
				msg = ErrorMessages.MissingPhoneNumber;
				return false;
			}
			else if (!Address.IsValid(ref msg))
			{
				return false;
			}

			return true;

		}
	}
}

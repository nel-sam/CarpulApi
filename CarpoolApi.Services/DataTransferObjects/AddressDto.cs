using System;
namespace CarpoolApi.Service.DataTransferObjects
{
    public class AddressDto
    {
        public AddressDto() { }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

		public bool IsValid(ref string msg)
		{
			if (String.IsNullOrEmpty(StreetNumber))
			{
				msg = ErrorMessages.MissingStreetNumber;
				return false;
			}
			else if (String.IsNullOrEmpty(City))
			{
				msg = ErrorMessages.MissingCity;
				return false;
			}
			else if (String.IsNullOrEmpty(State))
			{
				msg = ErrorMessages.MissingState;
				return false;
			}
			else if (String.IsNullOrEmpty(ZipCode))
			{
				msg = ErrorMessages.MissingZipCode;
				return false;
			}

			return true;
		}
    }
}

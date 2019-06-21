using CarpoolApi.Api.Properties.Controllers;
using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Service;
using CarpoolApi.Service.DataTransferObjects;
using CarpoolApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserDetails> userDetailsMock = new Mock<IUserDetails>();
        private UserService userService;
		private ProfileDto profileDto;
		private AddressDto addressDto;

		[TestInitialize]
		public void TestInitialize() => this.userService = new UserService(this.userDetailsMock.Object);

		[TestMethod]
        public void GetUserByEmail_WhenUserExists_ShouldReturnUser()
        {
            var email = "testUser@test.com";
            this.userDetailsMock.Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(new UserAggregate
                {
                    Email = email,
                    User = new User(),
                    Address = new Address(),
                    UserType = new UserType
                    {
                        Type = "Admin"
                    }
                });

            var result = this.userService.GetUser(email);

            Assert.IsNotNull(result);
            Assert.AreEqual(email, result.Email);
        }

        [TestMethod]
        public void GetUserByEmail_WhenUserDoesNotExist_ShouldReturnNull()
        {
            this.userDetailsMock.Setup(x => x.GetUser(It.IsAny<string>())).Returns((UserAggregate)null);
            var result = this.userService.GetUser("thisGuyDoesNotExist@no.com");

            Assert.IsNull(result);
        }

		[TestMethod]
		public void ProfileDtoIsValid_WhenMissingData_ShouldReturnFalse()
		{
			this.profileDto = new ProfileDto();

			string msg = null;
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingFirstName);

			this.profileDto.FirstName = "FirstName";
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingLastName);

			this.profileDto.LastName = "LastName";
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingEmail);

			this.profileDto.Email = "Email";
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingPassword);

			this.profileDto.Password = "Password";
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingAreaCode);

			this.profileDto.AreaCode = "AreaCode";
			Assert.IsFalse(profileDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingPhoneNumber);
		}

		[TestMethod]
		public void AddressDtoIsValid_WhenMissingData_ShouldReturnFalse()
		{
			this.addressDto = new AddressDto();

			string msg = null;
			Assert.IsFalse(addressDto.IsValid(ref msg));
			Assert.AreEqual(msg,ErrorMessages.MissingStreetNumber);

			this.addressDto.StreetNumber = "StreeNumber";
			Assert.IsFalse(addressDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingCity);

			this.addressDto.City = "City";
			Assert.IsFalse(addressDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingState);

			this.addressDto.State = "State";
			Assert.IsFalse(addressDto.IsValid(ref msg));
			Assert.AreEqual(msg, ErrorMessages.MissingZipCode);
		}

		[TestMethod]
		public void ProfileDtoIsValid_WhenDataExists_ShouldReturnTrue()
		{
			this.profileDto = new ProfileDto
			{
				FirstName = "FirstName",
				LastName = "LastName",
				Email = "Email",
				Password = "Password",
				AreaCode = "AreaCode",
				PhoneNumber = "PhoneNumber",
				Address = new AddressDto
				{
					StreetNumber = "StreetNumber",
					City = "City",
					State = "State",
					ZipCode = "ZipCode"
				}
			};

			string msg = null;

			Assert.IsTrue(profileDto.IsValid(ref msg));
		}

		[TestMethod]
		public void AddressDtoIsValid_WhenDataExists_ShouldReturnTrue()
		{
			this.addressDto = new AddressDto
			{
				StreetNumber = "StreetNumber",
				City = "City",
				State = "State",
				ZipCode = "ZipCode"
			};

			string msg = null;

			Assert.IsTrue(addressDto.IsValid(ref msg));
		}

	}
}

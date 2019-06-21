using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CarpoolServiceTests
    {
        private Mock<ICarpoolDetails> carpoolDetailsMock = new Mock<ICarpoolDetails>();
        private Mock<IAddressDetails> addressDetailsMock = new Mock<IAddressDetails>();
        private Mock<ICampusDetails> campusDetailsMock = new Mock<ICampusDetails>();
        private Mock<IUserDetails> userDetailsMock = new Mock<IUserDetails>();
        private CarpoolService carpoolService;

        [TestInitialize]
        public void TestInitialize()
        {
            this.carpoolService = new CarpoolService(
                this.carpoolDetailsMock.Object,
                this.addressDetailsMock.Object,
                this.campusDetailsMock.Object,
                this.userDetailsMock.Object);
        }

        [TestMethod]
        public void GetCarpoolById_WhenCarpoolExists_ShouldReturnCarpool()
        {
            var id = 1;

            this.carpoolDetailsMock.Setup(x => x.GetCarpoolById(It.IsAny<int>()))
                .Returns(new CarpoolAggregate
                {
                    Id = id,
                    Cars = new List<Car>(),
                    Destination = new Address(),
                    Certificates = new List<Certificate>()
                    {
                        new Certificate
                        {
                            CreateDate = DateTime.Now,
                            ExpiryDate = DateTime.Now.AddDays(1),
                            IncentiveType = new IncentiveType { Description = "SomeType" },
                            Id = 1,
                            Carpool = new Carpool
                            {
                                Id = 1,
                                Campus = new Campus(),
                                Cars = new List<Car>(),
                                Users = new List<User>(),
                                Requests = new List<Request>(),
                                Certificates = new List<Certificate>(),
                            }
                        }
                    },
                    Users = new List<User>
                    {
                        new User
                        {
                            Carpool = new Carpool
                            {
                                Id = 1,
                                Campus = new Campus(),
                                Cars = new List<Car>(),
                                Users = new List<User>(),
                                Requests = new List<Request>(),
                                Certificates = new List<Certificate>(),
                            }
                        }
                    },
                });

            var result = this.carpoolService.GetCarpoolById(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCarpoolById_WhenCarpoolDoesNotExist_ShouldReturnNull()
        {
            this.carpoolDetailsMock.Setup(x => x.GetCarpoolById(It.IsAny<int>()))
                .Returns((CarpoolAggregate)null);

            var result = this.carpoolService.GetCarpoolById(9999);

            Assert.IsNull(result);
        }
    }
}

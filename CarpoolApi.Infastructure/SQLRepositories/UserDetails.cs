using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Infastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolApi.Infrastructure.SQLRepositories
{
    public class UserDetails : IUserDetails
    {
        private DatabaseContext _dbContext;

        public UserDetails(DatabaseContext context)
        {
            _dbContext = context;
        }

        public UserAggregate GetUser(string email)
        {
            var model = GetUserModel(email);
            return BuildUserAggregateBy(model);
        }

        private UserAggregate BuildUserAggregateBy(User userEntity)
        {
            UserAggregate userAggregate = new UserAggregate
            {
				User = userEntity,
				Email = userEntity.Email,
				UserType = userEntity.UserType,
				Address = userEntity.Address,
				Carpool = userEntity.Carpool
			};

			userEntity.UserPhones.ForEach(up => userAggregate.addPhoneNumber(up.PhoneNumber));
            userEntity.UserCars.ForEach(up => userAggregate.addCar(up.Car));

			if (userEntity.Carpool != null)
			{
				userEntity.Carpool.Requests.ForEach(ir => userAggregate.addInboundRequest(ir));
			}

			userEntity.Requests.ForEach(or => userAggregate.addOutboundRequest(or));

            return userAggregate;
        }

        public void Add(UserAggregate user)
        {
			_dbContext.Addresses.Add(user.Address);
			user.User.Address = user.Address;
			user.User.UserType = _dbContext.UserTypes.FirstOrDefault(x => x.Type == "Carpool Member");
			_dbContext.Users.Add(user.User);

            foreach (PhoneNumber phoneNumber in user.PhoneNumbers)
            {
                _dbContext.PhoneNumbers.Add(phoneNumber);

                UserPhone userPhone = new UserPhone();

                userPhone.PhoneNumber = phoneNumber;
                userPhone.PhoneNumberId = phoneNumber.Id;

                userPhone.User = user.User;
                userPhone.UserId = user.User.Id;

                _dbContext.UserPhones.Add(userPhone);
            }

            _dbContext.SaveChanges();
        }

        public UserType GetUserType(string description) =>
            _dbContext.UserTypes.FirstOrDefault(ut => ut.Type.Equals(description, StringComparison.InvariantCultureIgnoreCase));

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        private Address GetAddressBy(int userId)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == userId).Address;
        }

        public User GetUserModel(string email)
        {
			return _dbContext.Users
								.Include(a => a.Address)
                                .Include(r => r.Requests)
                                    .ThenInclude(rcp => rcp.Carpool)
                                .Include(uc => uc.UserCars)
                                    .ThenInclude(c => c.Car)
                                .Include(up => up.UserPhones)
                                    .ThenInclude(p => p.PhoneNumber)
                                .Include(ut => ut.UserType)
                                .Include(cp => cp.Carpool)
                                    .ThenInclude(cpr => cpr.Requests)
                                        .ThenInclude(usr => usr.User)
                                .FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        private List<PhoneNumber> GetPhoneNumberBy(int userId)
        {
            return _dbContext.UserPhones
                                .Include(p => p.PhoneNumber)
                                .Select(p => p.PhoneNumber)
                                .ToList();
        }

        private List<Car> GetCarsBy(int userId)
        {
            if (_dbContext.UserCars.FirstOrDefault(x => x.User.Id == userId) != null)
            {
                return _dbContext.UserCars
                    .Include(c => c.Car)
                    .Select(c => c.Car)
                    .ToList();
            }
            else
            {
                return null;
            }
        }

        private List<Request> GetRequestsBy(int userId)
        {
            return _dbContext.Requests.Where(r => r.UserId == userId).ToList();
        }
    }
}

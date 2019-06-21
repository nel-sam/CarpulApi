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
    public class CarpoolDetails : ICarpoolDetails
    {
        private DatabaseContext _dbContext;

        public CarpoolDetails(DatabaseContext context) => _dbContext = context;

        public List<CarpoolAggregate> GetCarpoolsByZipcode(string zipcode)
        {
            var carpools = _dbContext.Certificates
                .Include(c => c.Carpool)
                    .ThenInclude(c => c.Campus)
                        .ThenInclude(c => c.Address)
                .Include(c => c.IncentiveType)
                .Include(c => c.Carpool)
                    .Include(c => c.Carpool.Users)
                .Include(c => c.Carpool)
                    .ThenInclude(c => c.Cars)
                .Where(c => c.Carpool.Campus.Address.ZipCode == zipcode)
                .Select(cert => new CarpoolAggregate
                {
                    Id = cert.Carpool.Id,
                    Cars = cert.Carpool.Cars,
                    Destination = cert.Carpool.Campus.Address,
                    Users = cert.Carpool.Users
                }).ToList();

            foreach (var carpool in carpools)
            {
                carpool.Certificates = _dbContext.Certificates
                    .Where(c => c.Carpool.Campus.Address.ZipCode == zipcode)
                    .ToList();
            }

            return carpools;
        }

        public List<CarpoolAggregate> GetAllCarpools()
        {

			var carpoolModels = _dbContext.Carpools
									.Include(c => c.Certificates)
										.ThenInclude(cert => cert.IncentiveType)
									.Include(c => c.Cars)
									.Include(c => c.Users)
										.ThenInclude(u => u.UserType)
									.Include(c => c.Campus)
										.ThenInclude(cam => cam.Address)
									.Include(c => c.Requests)
										.ThenInclude(r => r.User)
									.ToList();

			List<CarpoolAggregate> carpools = new List<CarpoolAggregate>();

			foreach (Carpool carpoolModel in carpoolModels)
			{
				CarpoolAggregate carpool = new CarpoolAggregate
				{
					Certificates = carpoolModel.Certificates,
					Cars = carpoolModel.Cars,
					Destination = carpoolModel.Campus.Address,
					Id = carpoolModel.Id,
				};

				carpoolModel.Users.ForEach(
				    usr => usr.Address = _dbContext.Users
										    .Include(u => u.Address)
										    .FirstOrDefault(u => u.Id == usr.Id)
										    .Address);
				carpool.Users = carpoolModel.Users;
				carpools.Add(carpool);									
			}

			return carpools;
        }

        public CarpoolAggregate GetCarpoolById(int id)
        {
            var carpoolRaw = _dbContext.Carpools
                .Include(x => x.Certificates)
                    .ThenInclude(c => c.IncentiveType)
                .Include(x => x.Users)
                    .ThenInclude(u => u.Address)
                .Include(x => x.Users)
                    .ThenInclude(u => u.Carpool)
                .Include(x => x.Cars)
                .Include(x => x.Requests)
                .Include(x => x.Campus)
                    .ThenInclude(c => c.Address)
                .Include(x => x.Users)
                    .ThenInclude(u => u.UserType)
                .FirstOrDefault(c => c.Id == id);

            if (carpoolRaw == null)
                throw new KeyNotFoundException();

            return new CarpoolAggregate
            {
                Id = id,
                Certificates = carpoolRaw.Certificates,
                Users = carpoolRaw.Users,
                Destination = carpoolRaw.Campus.Address,
                Cars = carpoolRaw.Cars
            };
        }

        public void DeleteCarpool(int id, string ownerEmail)
        {
            var carpool = _dbContext.Carpools.FirstOrDefault(c => c.Id == id);

            if (carpool == null)
                throw new KeyNotFoundException("Carpool was not found");

            var owner = _dbContext.Users.FirstOrDefault(u => u.Email.Equals(ownerEmail, StringComparison.InvariantCultureIgnoreCase));

            // Free the owner from the carpool first
            owner.Carpool = null;
            var memberType = _dbContext.UserTypes.FirstOrDefault(t => t.Type.Contains("Member", StringComparison.InvariantCultureIgnoreCase));
            owner.UserType = memberType;
           
            _dbContext.Carpools.Remove(carpool);
            _dbContext.SaveChanges();
        }

        public void LeaveCarpool(int id, string userEmail)
        {
            var carpool = _dbContext.Carpools.FirstOrDefault(c => c.Id == id);

            if (carpool == null)
                throw new KeyNotFoundException("Carpool was not found");

            var member = _dbContext.Users.FirstOrDefault(u => u.Email.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase));
            member.Carpool = null;
            _dbContext.SaveChanges();
        }

        public void PersistRequest(string firstName, string lastName, string message, int carpoolId, int approval)
        {
            Request request = new Request
            {
                Message = message,
                Approval = approval,
                UserId = _dbContext.Users.FirstOrDefault(usr => usr.FirstName == firstName && usr.LastName == lastName).Id,
                CarpoolId = carpoolId
            };

            _dbContext.Requests.Add(request);
            _dbContext.SaveChanges();
		}


		public void AddCarpool(Carpool carpool)
        {
            _dbContext.Carpools.Add(carpool);
            _dbContext.SaveChanges();
        }

		public void ApproveRequest(string firstName, string lastName, int carpoolId)
		{
			//Get request by user firstName, lastName, and carpoolId
			Request request = GetRequestBy(firstName, lastName, carpoolId);

			//Set Request status to approved
			request.Approval = 1;

			//Set user carpool foreign key to carpool id
			User user = _dbContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
			user.Carpool = _dbContext.Carpools.FirstOrDefault(c => c.Id == carpoolId);

			//Persist in database
			_dbContext.Update(request);
			_dbContext.Update(user);
			_dbContext.SaveChanges();			
		}

		public void RejectRequest(string firstName, string lastName, int carpoolId)
		{
			//Get request by user firstName, lastName, and carpoolId
			Request request = GetRequestBy(firstName, lastName, carpoolId);

			//Set Request status to Rejected
			request.Approval = 2;

			//Persist in database
			_dbContext.Update(request);
			_dbContext.SaveChanges();
		}

		public void DeleteRequest(string userEmail, int carpoolId)
		{
			//Get request by user firstName, lastName, and carpoolId
			Request request = GetRequestByEmail(userEmail, carpoolId);
            
            if (request == null)
                return;

            //Remove in database
            _dbContext.Requests.Remove(request);
			_dbContext.SaveChanges();
		}

        public IncentiveType GetIncentiveType(int id) =>
            _dbContext.IncentiveTypes.FirstOrDefault(i => i.Id == id);

		private Request GetRequestBy(string firstName, string lastName, int carpoolId)
		{
			return _dbContext.Requests.FirstOrDefault(r => r.User.FirstName == firstName && r.User.LastName == lastName && r.CarpoolId == carpoolId);
		}

        private Request GetRequestByEmail(string userEmail, int carpoolId)
        {
            return _dbContext.Requests.FirstOrDefault(r => r.User.Email.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase) && r.CarpoolId == carpoolId);
        }
    }
}
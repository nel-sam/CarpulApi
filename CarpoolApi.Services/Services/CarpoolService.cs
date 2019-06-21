using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Enums;
using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Service;
using CarpoolApi.Service.DataTransferObjects;
using CarpoolApi.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolApi.Services
{
	public class CarpoolService : ICarpoolService
    {
        private ICarpoolDetails _carpoolDetails;
        private IAddressDetails _addressDetails;
        private ICampusDetails _campusDetails;
        private IUserDetails _userDetails;
        
        public CarpoolService(
            ICarpoolDetails carpoolDetails, 
            IAddressDetails addressDetails,
            ICampusDetails campusDetails,
            IUserDetails userDetails)
        {
            _carpoolDetails = carpoolDetails;
            _addressDetails = addressDetails;
            _campusDetails = campusDetails;
            _userDetails = userDetails;
        }

        public List<CarpoolDto> GetAllCarpools()
        {
            var result = new List<CarpoolDto>();
            var carpools = _carpoolDetails.GetAllCarpools();

            foreach (var carpool in carpools)
            {
                if (carpool == null)
                    return null;

                var certificates = carpool.Certificates;

                if (certificates == null || certificates.Count == 0)
                    continue;

                var latestCertificate = carpool.Certificates
                    .OrderByDescending(c => c.ExpiryDate)
                    .First();

                var owner = carpool.Users
                    .Select(u => new UserDto
                    {
                        Address = new AddressDto
                        {
                            City = u.Address?.City,
                            State = u.Address?.State,
                            ZipCode = u.Address?.ZipCode,
                            StreetNumber = u.Address?.StreetNumber,
                        },
                        Email = u.Email,
                        LastName = u.LastName,
                        FirstName = u.FirstName,
                        CarpoolId = u.Carpool?.Id ?? -1,
                        UserType = u.UserType?.Type,
                        PhoneNumber = u.UserPhones?.Select(p => p.PhoneNumber?.Number).ToList(),
                        Cars = u.Carpool?.Cars.Select(c => new CarDto
                        {
                            LicensePlateNo = c.LicensePlateNo,
                            Model = c.Model,
                            Color = c.Color,
                            Make = c.Make,
                            Year = c.Year,
                        }).ToList(),
                        InboundRequests = u.Carpool?.Requests.Select(r => new RequestDto
                        {
                            Approval = r.Approval.ToString(),
                            FirstName = r.User?.FirstName,
                            LastName = r.User?.LastName,
                            CarpoolId = r.CarpoolId,
                            Message = r.Message,
                        })
                        .Where(r => r.CarpoolId == latestCertificate.Carpool?.Id).ToList(),
                        OutboundRequests = u.Carpool?.Requests?.Select(r => new RequestDto
                        {
                            Approval = r.Approval.ToString(),
                            FirstName = r.User?.FirstName,
                            LastName = r.User?.LastName,
                            CarpoolId = r.CarpoolId,
                            Message = r.Message,
                        })
                        .Where(r => r.CarpoolId != latestCertificate.Carpool?.Id).ToList(),
                    })
                    .FirstOrDefault(u => u.UserType == "Carpool Owner");

				var members = carpool.Users
					.Select(m => new UserDto{
							Email = m.Email,
							FirstName = m.FirstName,
							LastName = m.LastName,
							UserType = m.UserType.Type
						}
					)
					.ToList();


				result.Add(new CarpoolDto
				{
                    Owner = owner,
                    Id = carpool.Id,
                    Destination = carpool.Destination,
                    Created = latestCertificate.CreateDate,
					Expires = latestCertificate.ExpiryDate,
                    Campus = latestCertificate.Carpool?.Campus.Name,
                    Incentive = latestCertificate.IncentiveType?.Description,
                    Members = members.Where(m => m.UserType == "Carpool Member").ToList()					
                });
            }

            return result;
        }

        public CarpoolDto GetCarpoolById(int id)
        {
            var carpool = _carpoolDetails.GetCarpoolById(id);

            if (carpool == null)
                return null;

            var certificates = carpool.Certificates;

            if (certificates == null || certificates.Count == 0)
                return null;

            var latestCertificate = carpool.Certificates
                .OrderByDescending(c => c.ExpiryDate)
                .First();

            var owner = latestCertificate.Carpool.Users
                .Select(u => new UserDto
                {
                    Address = new AddressDto
                    {
                        City = u.Address.City,
                        State = u.Address.State,
                        ZipCode = u.Address.ZipCode,
                        StreetNumber = u.Address.StreetNumber,
                    },
                    Email = u.Email,
                    LastName = u.LastName,
                    FirstName = u.FirstName,
                    CarpoolId = u.Carpool.Id,
                    UserType = u.UserType.Type,
                    PhoneNumber = u.UserPhones?.Select(p => p.PhoneNumber?.Number).ToList(),
                    Cars = u.Carpool.Cars.Select(c => new CarDto
                    {
                        LicensePlateNo = c.LicensePlateNo,
                        Model = c.Model,
                        Color = c.Color,
                        Make = c.Make,
                        Year = c.Year,
                    }).ToList(),
                    InboundRequests = u.Carpool.Requests.Select(r => new RequestDto
                    {
                        Approval = r.Approval.ToString(),
                        FirstName = r.User?.FirstName,
                        LastName = r.User?.LastName,
                        CarpoolId = r.CarpoolId,
                        Message = r.Message,
                    })
                    .Where(r => r.CarpoolId == id).ToList(),
                    OutboundRequests = u.Carpool.Requests.Select(r => new RequestDto
                    {
                        Approval = r.Approval.ToString(),
                        FirstName = r.User?.FirstName,
                        LastName = r.User?.LastName,
                        CarpoolId = r.CarpoolId,
                        Message = r.Message,
                    })
                    .Where(r => r.CarpoolId != id).ToList(),
                })
                .FirstOrDefault(u => u.UserType == "Carpool Owner");

            var members = carpool.Users
                    .Select(m => new UserDto
                    {
                        Email = m.Email,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        UserType = m.UserType.Type
                    }
                    )
                    .ToList();

            return new CarpoolDto
            {
                Owner = owner,
                Id = carpool.Id,
                Destination = carpool.Destination,
                Created = latestCertificate.CreateDate,
                Expires = latestCertificate.ExpiryDate,
                Campus = latestCertificate.Carpool.Campus.Name,
                Incentive = latestCertificate.IncentiveType.Description,
                Members = members.Where(m => m.UserType == "Carpool Member").ToList()
            };
        }

        public IEnumerable<CarpoolDto> GetCarpoolsByZipcode(string zipcode)
        {
            List<CarpoolAggregate> carpoolAggregates = _carpoolDetails.GetCarpoolsByZipcode(zipcode);

            foreach (var carpool in carpoolAggregates)
            {
                var latestCert = carpool.Certificates
                    .OrderByDescending(c => c.ExpiryDate)
                    .First();

                var users = latestCert.Carpool.Users
                    .Select(u => new UserDto
                    {
                        Address = new AddressDto
                        {
                            City = u.Address.City,
                            State = u.Address.State,
                            ZipCode = u.Address.ZipCode,
                            StreetNumber = u.Address.StreetNumber,
                        },
                        Email = u.Email,
                        LastName = u.LastName,
                        FirstName = u.FirstName,
                        CarpoolId = u.Carpool.Id,
                        UserType = u.UserType.Type,
                        PhoneNumber = u.UserPhones?.Select(p => p.PhoneNumber?.Number).ToList(),
                        Cars = u.Carpool.Cars.Select(c => new CarDto
                        {
                            LicensePlateNo = c.LicensePlateNo,
                            Model = c.Model,
                            Color = c.Color,
                            Make = c.Make,
                            Year = c.Year,
                        }).ToList(),
                        InboundRequests = u.Carpool.Requests.Select(r => new RequestDto
                        {
                            Approval = r.Approval.ToString(),
                            FirstName = r.User?.FirstName,
                            LastName = r.User?.LastName,
                            CarpoolId = r.CarpoolId,
                            Message = r.Message,
                        }).ToList(),             
                        OutboundRequests = u.Carpool.Requests.Select(r => new RequestDto
                        {
                            Approval = r.Approval.ToString(),
                            FirstName = r.User?.FirstName,
                            LastName = r.User?.LastName,
                            CarpoolId = r.CarpoolId,
                            Message = r.Message,
                        }).ToList()
                    }).ToList();

                yield return new CarpoolDto
                {
                    Members = users,
                    Created = latestCert.CreateDate,
                    Expires = latestCert.ExpiryDate,
                    Campus = latestCert.Carpool.Campus.Name,
                    Incentive = latestCert.IncentiveType?.Description
                };
            }
        }

		public void ActionRequest(RequestDto request, string userEmail)
		{
			switch ((Enums.Action)System.Enum.Parse(typeof(Enums.Action), request.Action,true))
			{
				case Enums.Action.Create:
					_carpoolDetails.PersistRequest(request.FirstName, request.LastName, request.Message, request.CarpoolId, (int)Enums.Status.Pending);
					break;

				case Enums.Action.Approve:
					_carpoolDetails.ApproveRequest(request.FirstName, request.LastName, request.CarpoolId);
					break;

				case Enums.Action.Reject:
					_carpoolDetails.RejectRequest(request.FirstName, request.LastName, request.CarpoolId);
					break;

				case Enums.Action.Delete: 
                    var carpool = GetCarpoolById(request.CarpoolId);

                    // See if the user is either the owner or a member of the carpool
                    var userIsOwner = userEmail.Equals(carpool.Owner.Email, StringComparison.InvariantCultureIgnoreCase);

                    // Make sure the user is an actual member of the carpool
                    var userIsMember = carpool.Members.FirstOrDefault(m => m.Email.Equals(userEmail, StringComparison.InvariantCultureIgnoreCase)) != null;

					if (!userIsOwner && !userIsMember)
					{
						_carpoolDetails.DeleteRequest(userEmail, request.CarpoolId);
					}
					else if (userIsMember)
					{
						_carpoolDetails.DeleteRequest(userEmail, request.CarpoolId);
						LeaveCarpool(request.CarpoolId, userEmail);
					}
					else if (userIsOwner)
					{
						DeleteCarpool(request.CarpoolId, userEmail);
					}
                    
					break;
			}
		}

		public int CreateCarpool(CarpoolCreationRequestDto carpool)
		{
            var addressObj = _addressDetails.Get(
                                carpool.Address.StreetNumber,
                                carpool.Address.City,
                                carpool.Address.State,
                                carpool.Address.ZipCode);

            if (addressObj == null)
            {
                addressObj = new Address
                {
                    StreetNumber = carpool.Address.StreetNumber,
                    City = carpool.Address.City,
                    State = carpool.Address.State,
                    ZipCode = carpool.Address.ZipCode,
                };

                _addressDetails.Add(addressObj);
            }

            var campusObj = _campusDetails.Get(carpool.CampusName);

            if (campusObj == null)
            {
                campusObj = new Campus
                {
                    Address = addressObj,
                    Name = carpool.CampusName,
                };

                _campusDetails.Add(campusObj);
            }

            var newCarpool = new Carpool
            {
                Campus = campusObj,
                Certificates = new List<Certificate>
                {
                    new Certificate
                    {
                        CreateDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddDays(365),
                        IncentiveType = _carpoolDetails.GetIncentiveType(carpool.IncentiveId),
                    }
                }
            };

            _carpoolDetails.AddCarpool(newCarpool);

            var owner = _userDetails.GetUserModel(carpool.UserEmail);
            var userType = _userDetails.GetUserType("Carpool Owner");
            owner.UserType = userType;
            owner.Carpool = newCarpool;
            _userDetails.Update(owner);
            return newCarpool.Id;
        }

        public void DeleteCarpool(int id, string ownerEmail) => _carpoolDetails.DeleteCarpool(id, ownerEmail);

        public void LeaveCarpool(int id, string userEmail) => _carpoolDetails.LeaveCarpool(id, userEmail);
    }
}

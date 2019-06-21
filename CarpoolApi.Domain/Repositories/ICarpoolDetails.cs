using CarpoolApi.Domain.Aggregates;
using CarpoolApi.Domain.Models;
using System.Collections.Generic;

namespace CarpoolApi.Domain.Repositories
{
    public interface ICarpoolDetails
    {
        void PersistRequest(string firstName, string lastName, string message, int carpoolId, int approval);
		void ApproveRequest(string firstName, string lastName, int carpoolId);
		void RejectRequest(string firstName, string lastName, int carpoolId);
		void DeleteRequest(string userEmail, int carpoolId);
        List<CarpoolAggregate> GetCarpoolsByZipcode(string zipcode);
        List<CarpoolAggregate> GetAllCarpools();
        CarpoolAggregate GetCarpoolById(int id);
        IncentiveType GetIncentiveType(int id);
        void AddCarpool(Carpool carpool);
        void DeleteCarpool(int id, string ownerEmail);
        void LeaveCarpool(int id, string userEmail);
    }
}
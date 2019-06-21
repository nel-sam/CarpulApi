using CarpoolApi.Service.DataTransferObjects;
using System.Collections.Generic;

namespace CarpoolApi.Service.Services
{
    public interface ICarpoolService
    {
        CarpoolDto GetCarpoolById(int id);
        List<CarpoolDto> GetAllCarpools();
		void ActionRequest(RequestDto request, string userEmail);
        int CreateCarpool(CarpoolCreationRequestDto carpool);
        void DeleteCarpool(int id, string ownerEmail);
        void LeaveCarpool(int id, string userEmail);
        IEnumerable<CarpoolDto> GetCarpoolsByZipcode(string zipcode);
    }
}

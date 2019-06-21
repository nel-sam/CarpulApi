namespace CarpoolApi.Service.DataTransferObjects
{
    public class CarpoolCreationRequestDto
    {
        public int IncentiveId { get; set; }
        public string UserEmail { get; set; }
        public string CampusName { get; set; }
        public AddressDto Address { get; set; }
    }
}

namespace CarpoolApi.Domain.Models
{
    public class Request
    {
        public string Message { get; set; }
        public int Approval { get; set; }
        public int CarpoolId { get; set; }
        public Carpool Carpool { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

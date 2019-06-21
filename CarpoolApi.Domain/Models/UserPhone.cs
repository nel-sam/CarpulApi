namespace CarpoolApi.Domain.Models
{
    public class UserPhone
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }
}

using System;

namespace CarpoolApi.Domain.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public IncentiveType IncentiveType { get; set; }
        public Carpool Carpool { get; set; }
        
    }
}

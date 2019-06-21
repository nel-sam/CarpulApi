using CarpoolApi.Domain.Models;
using System;
using System.Collections.Generic;

namespace CarpoolApi.Domain.Aggregates
{
    public class CarpoolAggregate
    {
        public int Id { get; set; }
        public List<Car> Cars { get; set; }
        public List<User> Users { get; set; }
        public Address Destination { get; set; }
        public List<Certificate> Certificates { get; set; }
    }
}

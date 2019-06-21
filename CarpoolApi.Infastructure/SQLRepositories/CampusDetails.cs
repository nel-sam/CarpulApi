using CarpoolApi.Domain.Models;
using CarpoolApi.Domain.Repositories;
using CarpoolApi.Infastructure;
using System;
using System.Linq;

namespace CarpoolApi.Infrastructure.SQLRepositories
{
    public class CampusDetails : ICampusDetails
    {
        private DatabaseContext _dbContext;

        public CampusDetails(DatabaseContext context) => _dbContext = context;

        public void Add(Campus campus)
        {
            _dbContext.Campuses.Add(campus);
            _dbContext.SaveChanges();
        }

        public Campus Get(string name) => 
            _dbContext.Campuses.FirstOrDefault(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }
}

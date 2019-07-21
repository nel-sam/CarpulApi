using CarpoolApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace CarpoolApi.Infastructure
{
    public class DatabaseContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public DatabaseContext(IConfiguration configuration) => Configuration = configuration;

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Carpool> Carpools { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        //public DbSet<Email> Emails { get; set; }
        public DbSet<IncentiveType> IncentiveTypes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationCampus> OrganizationCampuses { get; set; }
        public DbSet<CampusType> CampusTypes { get; set; }
        public DbSet<CampusTypeCampus> CampusTypeCampuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCar>().HasKey(x => new { x.CarId, x.UserId });
            modelBuilder.Entity<UserPhone>().HasKey(x => new { x.PhoneNumberId, x.UserId });
            modelBuilder.Entity<OrganizationCampus>().HasKey(x => new { x.CampusId, x.OrganizationId });
            modelBuilder.Entity<CampusTypeCampus>().HasKey(x => new { x.CampusId, x.CampusTypeId });
            modelBuilder.Entity<Request>().HasKey(x => new { x.UserId, x.CarpoolId });
            modelBuilder.Entity<Organization>().HasIndex(o => o.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Campus>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<UserType>().HasIndex(ut => ut.Type).IsUnique();
            modelBuilder.Entity<IncentiveType>().HasIndex(it => it.Description).IsUnique();

            modelBuilder.Entity<UserType>().HasData(
               new UserType { Id = 1, Type = "Carpool Owner" },
               new UserType { Id = 2, Type = "Carpool Member" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, StreetNumber = "2111 NE 25th Ave", City = "Hillsboro", State = "OR", ZipCode = "97124" },
                new Address { Id = 2, StreetNumber = "2501 SW 229th Ave", City = "Hillsboro", State = "OR", ZipCode = "97123" }
            );

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Email = "billy@intel.com", Password = Encoding.UTF8.GetBytes("p@ssw0rd") }
            );

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        }
    }
}

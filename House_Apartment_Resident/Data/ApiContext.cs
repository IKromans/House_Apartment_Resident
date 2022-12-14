using Microsoft.EntityFrameworkCore;
using HouseApartmentResidentApi.Model;

namespace HouseApartmentResidentApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Resident> Residents { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}

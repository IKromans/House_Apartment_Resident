using Microsoft.EntityFrameworkCore;
using House_Apartment_Resident.Model;

namespace House_Apartment_Resident.Data
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

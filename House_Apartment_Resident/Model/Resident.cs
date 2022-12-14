using System.ComponentModel.DataAnnotations;

namespace HouseApartmentResidentApi.Model
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonId { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNmber { get; set; }
        public string? Email { get; set; }
        public Apartment? Apartment { get; set; }

    }
}

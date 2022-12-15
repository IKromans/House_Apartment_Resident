using System.ComponentModel.DataAnnotations;

namespace House_Apartment_Resident.Model
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public int Population { get; set; }
        public int FullArea { get; set; }
        public int LivingArea { get; set; }
        public House? House { get; set; }

    }
}

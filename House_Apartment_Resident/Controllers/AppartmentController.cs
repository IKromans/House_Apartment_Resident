using HouseApartmentResidentApi.Data;
using HouseApartmentResidentApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HouseApartmentResidentApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly ApiContext context;

        public ApartmentController(ApiContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(Apartment apartment)
        {
            if (apartment.Id == 0)
            {
                context.Apartments.Add(apartment);
            }
            else
            {
                var apartmentInDb = context.Apartments.Find(apartment.Id);

                if (apartmentInDb == null)
                    return new JsonResult(NotFound());

                apartmentInDb.Number = apartment.Number;
                apartmentInDb.Floor = apartment.Floor;
                apartmentInDb.Rooms = apartment.Rooms;
                apartmentInDb.Population = apartment.Population;
                apartmentInDb.FullArea = apartment.FullArea;
                apartmentInDb.LivingArea = apartment.LivingArea;
                apartmentInDb.House = apartment.House;
            }

            context.SaveChanges();

            return new JsonResult(Ok(apartment));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var apartment = context.Apartments.Find(id);

            if (apartment == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(apartment));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var apartment = context.Apartments.Find(id);

            if (apartment == null)
                return new JsonResult(NotFound());

            context.Apartments.Remove(apartment);
            context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet()]
        public JsonResult GetAll()
        {
            var apartments = context.Apartments.ToList();

            return new JsonResult(Ok(apartments));
        }
    }
}
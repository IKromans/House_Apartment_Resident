using HouseApartmentResidentApi.Data;
using HouseApartmentResidentApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HouseApartmentResidentApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly ApiContext context;

        public HouseController(ApiContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(House house)
        {
            if (house.Id == 0)
            {
                context.Houses.Add(house);
            }
            else
            {
                var houseInDb = context.Houses.Find(house.Id);

                if (houseInDb == null)
                    return new JsonResult(NotFound());

                houseInDb.Number = house.Number;
                houseInDb.Street = house.Street;
                houseInDb.City = house.City;
                houseInDb.Country = house.Country;
                houseInDb.PostalCode = house.PostalCode;
            }

            context.SaveChanges();

            return new JsonResult(Ok(house));
        }


        [HttpGet]
        public JsonResult Get(int id)
        {
            var house = context.Houses.Find(id);

            if (house == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(house));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var house = context.Houses.Find(id);

            if (house == null)
                return new JsonResult(NotFound());

            context.Houses.Remove(house);
            context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet()]
        public JsonResult GetAll()
        {
            var house
                = context.Houses.ToList();

            return new JsonResult(Ok(house));
        }
    }
}
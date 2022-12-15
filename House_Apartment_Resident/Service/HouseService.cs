using House_Apartment_Resident.Data;
using House_Apartment_Resident.Model;
using Microsoft.AspNetCore.Mvc;

namespace House_Apartment_Resident.Service
{
    public class HouseService : ControllerBase
    {
        private readonly ApiContext context;

        public HouseService(ApiContext context)
        {
            this.context = context;
        }

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


        public JsonResult Get(int id)
        {
            var house = context.Houses.Find(id);

            if (house == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(house));
        }

        public JsonResult Delete(int id)
        {
            var house = context.Houses.Find(id);

            if (house == null)
                return new JsonResult(NotFound());

            context.Houses.Remove(house);
            context.SaveChanges();

            return new JsonResult(NoContent());
        }

        public JsonResult GetAll()
        {
            var house
                = context.Houses.ToList();

            return new JsonResult(Ok(house));
        }
    }
}
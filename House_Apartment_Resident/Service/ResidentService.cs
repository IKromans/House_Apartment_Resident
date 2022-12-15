using House_Apartment_Resident.Data;
using House_Apartment_Resident.Model;
using Microsoft.AspNetCore.Mvc;

namespace House_Apartment_Resident.Service
{
    public class ResidentService : ControllerBase
    {
        private readonly ApiContext context;

        public ResidentService(ApiContext context)
        {
            this.context = context;
        }

        public JsonResult CreateEdit(Resident resident)
        {
            if (resident.Id == 0)
            {
                context.Residents.Add(resident);
            }
            else
            {
                var residentInDb = context.Residents.Find(resident.Id);

                if (residentInDb == null)
                    return new JsonResult(NotFound());

                residentInDb.FirstName = resident.FirstName;
                residentInDb.LastName = resident.LastName;
                residentInDb.PersonId = resident.PersonId;
                residentInDb.BirthDate = resident.BirthDate;
                residentInDb.PhoneNmber = resident.PhoneNmber;
                residentInDb.Email = resident.Email;
                residentInDb.Apartment = resident.Apartment;
            }

            context.SaveChanges();

            return new JsonResult(Ok(resident));

        }

        public JsonResult Get(int id)
        {
            var result = context.Residents.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        public JsonResult Delete(int id)
        {
            var result = context.Residents.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            context.Residents.Remove(result);
            context.SaveChanges();

            return new JsonResult(NoContent());
        }

        public JsonResult GetAll()
        {
            var result = context.Residents.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
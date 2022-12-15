using House_Apartment_Resident.Service;
using House_Apartment_Resident.Data;
using House_Apartment_Resident.Model;
using Microsoft.AspNetCore.Mvc;

namespace House_Apartment_Resident.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResidentController
    {

        private readonly ResidentController service;

        public ResidentController(ApiContext context)
        {
            this.service = new ResidentController(context);
        }

        [HttpPost]
        public JsonResult CreateEdit(Resident resident)
        {
            return service.CreateEdit(resident);

        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            return service.Get(id);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return service.Delete(id);
        }

        [HttpGet()]
        public JsonResult GetAll()
        {
            return service.GetAll();
        }
    }
}
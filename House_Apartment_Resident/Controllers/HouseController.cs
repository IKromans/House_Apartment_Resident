using House_Apartment_Resident.Service;
using House_Apartment_Resident.Data;
using House_Apartment_Resident.Model;
using Microsoft.AspNetCore.Mvc;

namespace House_Apartment_Resident.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseController
    {

        private readonly HouseService service;

        public HouseController(ApiContext context)
        {
            this.service = new HouseService(context);
        }

        [HttpPost]
        public JsonResult CreateEdit(House house)
        {
            return service.CreateEdit(house);
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
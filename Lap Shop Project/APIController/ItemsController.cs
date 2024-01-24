using Lap_Shop_Project.BL;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lap_Shop_Project.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItems oItems;
        public ItemsController(IItems items) 
        {
            oItems = items;
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public ApiResponse Get()
        {
            ApiResponse response = new ApiResponse();
            response.Data=oItems.GetAll();
            response.Errors = null;
            response.StatusCode = "200";
            return response;
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            ApiResponse response = new ApiResponse();
            response.Data = oItems.GetById(id);
            response.Errors = null;
            response.StatusCode = "200";
            return response;
        }
            

        // POST api/<ItemsController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbItem item)
        {
            try
            {
            oItems.Save(item);
                ApiResponse response = new ApiResponse();
                response.Data = "Done";
                response.Errors = null;
                response.StatusCode = "200";
                return response;
            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse();
                response.Data = null;
                response.Errors = ex.Message;
                response.StatusCode = "502";
                return response;
            }
           
        }
       
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int id)
        {
            oItems.Delete(id);
        }
        // PUT api/<ItemsController>/5

    }
}

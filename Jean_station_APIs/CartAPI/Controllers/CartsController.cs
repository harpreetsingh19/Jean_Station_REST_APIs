using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService service;

        public CartsController(ICartService _service)
        {
            service = _service;
        }
        // GET: api/<CartsController>
        [HttpPost]
        [Route("getcartsbyuserid")]
        public IEnumerable<Cart> Get(Activeuser user)
        {
            string userid = user.UserId;
            return service.GetCarts(userid);
        }

        //GET api/<CartsController>/5
        [HttpGet("{id}")]
        public Cart GetCart(int id)
        {
            return service.GetCart(id);
        }

        // POST api/<CartsController>
        [HttpPost]
        public void Post([FromBody] Cart value)
        {
            service.AddToCart(value);
        }

        // PUT api/<CartsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.RemoveCart(id);
        }
    }
}

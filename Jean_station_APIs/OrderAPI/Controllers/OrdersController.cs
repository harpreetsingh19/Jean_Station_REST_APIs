using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService _service)
        {
            service = _service;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return service.GetOrders();
        }

        // GET api/<OrdersController>/5
        [HttpPost]
        [Route("getordersbyuserid")]
        public IEnumerable<Order> Get(Activeuser user)
        {
            string userid = user.UserId;
            return service.GetOrders(userid);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order value)
        {
            service.PlaceOrder(value);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order value)
        {
            service.UpdateOrderStatus(id, value);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.CancelOrder(id);
        }
    }
}

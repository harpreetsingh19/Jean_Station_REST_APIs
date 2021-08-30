using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService service;

        public AdminsController(IAdminService _service)
        {
            service = _service;
        }
        // GET: api/<CartsController>
        [HttpGet]
        [Route("getorders")]
        public IEnumerable<Order> GetOrders()
        {
            return service.GetOrders();
        }

        [HttpGet]
        [Route("getproducts")]
        public IEnumerable<Product> GetProducts()
        {
            return service.GetProducts();
        }

        //GET api/<CartsController>/5
        [HttpGet("{id}")]
        [Route("getproductsbyid")]
        public Product ProductById(int id)
        {
            return service.ProductById(id);
        }

        // POST api/<CartsController>
        [HttpPost]
        public void AddProduct([FromBody] Product value)
        {
            service.AddProduct(value);
        }

        // PUT api/<CartsController>/5
        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody] Product value)
        {
            service.UpdateProduct(id, value);
        }

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            service.DeleteProduct(id);
        }
    }
}

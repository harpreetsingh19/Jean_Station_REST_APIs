using Models;
using Repository;
using System.Collections.Generic;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;

        public AdminService(IAdminRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product ProductById(int id)
        {
            return _repo.ProductById(id);
        }
        public void AddProduct(Product product)
        {
            _repo.AddProduct(product);
        }
        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }
        public void UpdateProduct(int id, Product value)
        {
            _repo.UpdateProduct(id, value);
        }
    }
}

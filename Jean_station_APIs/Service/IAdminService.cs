using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IAdminService
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Product> GetProducts();
        Product ProductById(int id);
        void UpdateProduct(int id, Product value);
    }
}
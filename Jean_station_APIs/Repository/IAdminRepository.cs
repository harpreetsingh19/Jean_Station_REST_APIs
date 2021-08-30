using Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IAdminRepository
    {
        void AddProduct(Product value);
        void DeleteProduct(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Product> GetProducts();
        Product ProductById(int id);
        void UpdateProduct(int id, Product value);
    }
}
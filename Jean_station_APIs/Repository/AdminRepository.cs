using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminContext context;

        public AdminRepository(AdminContext _context)
        {
            context = _context;
        }
        public IEnumerable<Order> GetOrders()
        {
            var carts = context.Orders;
            return carts;
        }
        public IEnumerable<Product> GetProducts()
        {
            var products = context.Products;
            return products;
        }
        public Product ProductById(int id)
        {
            var product = context.Products.Where(s => s.Productid == id).FirstOrDefault();
            return product;
            //return context.Products.Find(id);
        }
        public void AddProduct(Product value)
        {
            context.Products.Add(value);
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
        public void UpdateProduct(int id, Product value)
        {
            var product = context.Products
            .Where(s => s.Productid == value.Productid).FirstOrDefault<Product>();
            if (product != null)
            {
                product.Description = value.Description;
                product.Image = value.Image;
                product.Productname = value.Productname;
                product.Price = value.Price;
                context.SaveChanges();
            }
        }
    }
}

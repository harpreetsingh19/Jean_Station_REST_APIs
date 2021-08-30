using Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CartContext context;

        public CartRepository(CartContext _context)
        {
            context = _context;
        }

        public void AddToCart(Cart value)
        {
            context.Carts.Add(value);
            context.SaveChanges();
        }
        public IEnumerable<Cart> GetCarts(string userid)
        {
            //var carts = context.Carts;
            //return carts;
            var cart = context.Carts.Where(x => x.Userid == userid).ToList();
            return cart;
        }
        public Cart GetCart(int id)
        {
            var cart = context.Carts.Where(x => x.Cartid == id).FirstOrDefault();
            return cart;
        }
        //public void UpdateProduct(int id, Product product)
        //{
        //    var filter = Builders<Product>.Filter.Where(p => p.ProductId == id);
        //    var update = Builders<Product>.Update.Set(p => p.Name, product.Name).Set(p => p.Brand, product.Brand).Set(p => p.Quantity, product.Quantity).Set(p => p.Price, product.Price);
        //    ptx.Products.UpdateOne(filter, update);
        //}
        public void RemoveCart(int id)
        {
            var cart = context.Carts.Find(id);
            context.Carts.Remove(cart);
            context.SaveChanges();
        }
    }
}

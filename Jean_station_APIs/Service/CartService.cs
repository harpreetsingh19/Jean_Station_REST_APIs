using Models;
using Repository;
using System.Collections.Generic;

namespace Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;

        public CartService(ICartRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Cart> GetCarts(string userid)
        {
            return _repo.GetCarts(userid);
        }
        public Cart GetCart(int id)
        {
            return _repo.GetCart(id);
        }
        public void AddToCart(Cart cart)
        {
            _repo.AddToCart(cart);
        }
        public void RemoveCart(int id)
        {
            _repo.RemoveCart(id);
        }
    }
}

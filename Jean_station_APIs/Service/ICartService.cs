using Models;
using System.Collections.Generic;

namespace Services
{
    public interface ICartService
    {
        void AddToCart(Cart cart);
        Cart GetCart(int id);
        IEnumerable<Cart> GetCarts(string userid);
        void RemoveCart(int id);
    }
}
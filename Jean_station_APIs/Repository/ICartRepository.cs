using Models;
using System.Collections.Generic;

namespace Repository
{
    public interface ICartRepository
    {
        void AddToCart(Cart value);
        Cart GetCart(int id);
        IEnumerable<Cart> GetCarts(string userid);
        void RemoveCart(int id);
    }
}
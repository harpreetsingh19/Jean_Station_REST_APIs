using Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IOrderRepository
    {
        void CancelOrder(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(string userid);
        void PlaceOrder(Order value);
        void UpdateOrderStatus(int id, Order value);
    }
}
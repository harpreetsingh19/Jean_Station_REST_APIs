using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderService
    {
        void CancelOrder(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(string userid);
        void PlaceOrder(Order Order);
        void UpdateOrderStatus(int id, Order value);
    }
}
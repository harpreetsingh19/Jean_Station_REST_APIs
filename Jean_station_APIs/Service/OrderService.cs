using Models;
using Repository;
using System.Collections.Generic;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _repo.GetOrders();
        }
        public IEnumerable<Order> GetOrders(string userid)
        {
            return _repo.GetOrders(userid);
        }
        public void PlaceOrder(Order Order)
        {
            _repo.PlaceOrder(Order);
        }
        public void CancelOrder(int id)
        {
            _repo.CancelOrder(id);
        }
        public void UpdateOrderStatus(int id, Order value)
        {
            _repo.UpdateOrderStatus(id, value);
        }
    }
}

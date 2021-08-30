using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext _context)
        {
            context = _context;
        }
        public IEnumerable<Order> GetOrders()
        {
            var carts = context.Orders;
            return carts;
        }
        public IEnumerable<Order> GetOrders(string userid)
        {
            var order = context.Orders.Where(x => x.Userid == userid).ToList();
            return order;
        }
        public void PlaceOrder(Order value)
        {
            context.Orders.Add(value);
            context.SaveChanges();
        }
        public void CancelOrder(int id)
        {
            var cart = context.Orders.Find(id);
            context.Orders.Remove(cart);
            context.SaveChanges();
        }
        public void UpdateOrderStatus(int id, Order value)
        {
            var order = context.Orders.Where(s => s.Orderid == value.Orderid).FirstOrDefault();
            order.Status = value.Status;
            context.SaveChanges();
        }
    }
}

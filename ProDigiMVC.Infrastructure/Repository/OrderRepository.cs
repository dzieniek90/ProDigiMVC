using ProDigiMVC.Domain.Interfaces;
using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context db;
        public OrderRepository(Context context)
        {
            db = context;
        }

        public void DeleteOrder(int orderId)
        {
            var order = db.Orders.Find(orderId);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public int AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.Id;
        }

        public IQueryable<Order> GetOrdersByOrderTypeId(int orderTypeId)
        {
            var orders = db.Orders.Where(x => x.OrderTypeId == orderTypeId);
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            var order = db.Orders.FirstOrDefault(p => p.Id == orderId);
            return order;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = db.Tags;
            return tags;
        }

        public IQueryable<OrderType> GetAllOrderTypes()
        {
            var orderTypes = db.OrderTypes;
            return orderTypes;
        }

        public IQueryable<OrderStatus> GetAllOrderStatuses()
        {
            var orderStatuses = db.OrderStatuses;
            return orderStatuses;
        }
    }
}

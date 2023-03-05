using ProDigiMVC.Domain.Model;

namespace ProDigiMVC.Domain.Interfaces
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        void DeleteOrder(int orderId);
        IQueryable<OrderStatus> GetAllOrderStatuses();
        IQueryable<OrderType> GetAllOrderTypes();
        IQueryable<Tag> GetAllTags();
        Order GetOrderById(int orderId);
        IQueryable<Order> GetOrdersByOrderTypeId(int orderTypeId);
    }
}
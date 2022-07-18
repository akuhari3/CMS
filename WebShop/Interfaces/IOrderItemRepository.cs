using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IOrderItemRepository
    {
        void CreateOrderItem(OrderItem orderItem);
        OrderItem GetOrderItemById(int id);
        void DeleteOrderItem(int id);
    }
}

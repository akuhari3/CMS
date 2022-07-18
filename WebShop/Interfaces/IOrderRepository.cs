using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);

        List<SelectListItem> GetUsersForDropDownList();
        
    }
}

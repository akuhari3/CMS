using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetUserOrders(string userId);
        ApplicationUser GetUserFromId(string id);
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);

        List<SelectListItem> GetUsersForDropDownList();
        List<SelectListItem> OrderStatesForDropDownList();


    }
}

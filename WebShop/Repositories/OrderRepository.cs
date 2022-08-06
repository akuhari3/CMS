using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Order Repository Implementation
        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Order.ToList();
        }

        public IEnumerable<Order> GetUserOrders(string userId)
        {
            return _dbContext.Order.Where(o => o.UserId == userId).ToList();
        }

        public Order GetOrderById(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.Id == id);

            order.OrderItems =
                (
                    from orderItems in _dbContext.OrderItem
                    where orderItems.OrderId == id
                    select new OrderItem
                    {
                        Id = orderItems.Id,
                        OrderId = orderItems.OrderId,
                        Quantity = orderItems.Quantity,
                        Total = orderItems.Total,
                        ProductId = orderItems.ProductId,
                        ProductName =
                        (
                        from product
                        in _dbContext.Product
                        where product.Id == orderItems.ProductId
                        select product.ProductName
                        )
                        .FirstOrDefault()
                    }
                ).ToList();

            return order;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Order.Update(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Order.Find(id);
            if(order != null)
            {
                _dbContext.Order.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        #endregion

        #region Order Item Repository Implementation

        public void CreateOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItem.Add(orderItem);
            _dbContext.SaveChanges();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _dbContext.OrderItem.Find(id);
        }

        public void DeleteOrderItem(int id)
        {
            var orderItem = _dbContext.OrderItem.Find(id);
            _dbContext.OrderItem.Remove(orderItem);
            _dbContext.SaveChanges();
        }

        #endregion

        #region DropDownList Users

        public List<SelectListItem> GetUsersForDropDownList()
        {
            return _dbContext.Users.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.UserName

            }).ToList();

        }
        #endregion


        
    }
}

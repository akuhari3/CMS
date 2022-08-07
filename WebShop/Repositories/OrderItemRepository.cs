using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public OrderItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Order Item Repository Implementation
        public List<OrderItem> GetOrderItems()
        {
            var orderItems = _dbContext.OrderItem.ToList();
            return orderItems;
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            var orderItems = _dbContext.OrderItem.Where(o => o.OrderId == orderId).ToList();
            foreach (var item in orderItems)
            {
                item.ProductName = _dbContext.Product.FirstOrDefault(p => p.Id == item.ProductId).ProductName;
            }
            return orderItems;
        }

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
    }
}

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

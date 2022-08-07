using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    public class OrderItemController : Controller
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public OrderItemController(IOrderRepository orderRepository, IProductRepository productRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }
        #endregion

        #region Order Item Action Methods

        public IActionResult Index()
        {
            var orderItems = _orderItemRepository.GetOrderItems();
            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productsDDL = _productRepository.GetProductsForDropDownList();

            ViewBag.Products = productsDDL;
            ViewBag.ProductsEntity = _productRepository.GetProducts();

            var products = _productRepository.GetProducts();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in products)
            {
                items.Add(new SelectListItem() { Text = item.ProductName, Value = item.Id.ToString() });
            }

            return View();
        }

        #endregion
    }
}

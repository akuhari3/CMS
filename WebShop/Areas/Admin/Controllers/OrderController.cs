using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }
        #endregion

        #region Order Action Methods
        public IActionResult Index()
        {
            return View(_orderRepository.GetOrders());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            return View(order);
        }

        public IActionResult Create()
        {
            ViewBag.Users = _orderRepository.GetUsersForDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }


        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            ViewBag.Users = _orderRepository.GetUsersForDropDownList();

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.UpdateOrder(order);
                return RedirectToAction("Index");
            }

            ViewBag.Users = _orderRepository.GetUsersForDropDownList();

            return View(order);
        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            return View(order);
        }


        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }
            _orderRepository.DeleteOrder(id);

            return RedirectToAction("Index");
        }

        #endregion

        #region Order Item Action Methods

        public IActionResult AddOrderItem(int id)
        {
            ViewBag.OrderId = id;

            ViewBag.Products = _productRepository.GetProductsForDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult AddOrderItem([Bind("OrderId, ProductId, Total, Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemRepository.CreateOrderItem(orderItem);

                return RedirectToAction("Details", new { id = orderItem.OrderId });
            }

            return View(orderItem);
        }

        public IActionResult DeleteOrderItem(int id)
        {
            var orderItem = _orderItemRepository.GetOrderItemById(id);
            _orderItemRepository.DeleteOrderItem(id);

            return RedirectToAction("Details", new { id = orderItem.OrderId });
        }

        #endregion

    }
}

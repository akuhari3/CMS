using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Extensions;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        const string _sessionKeyName = "_cart";
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, ApplicationDbContext dbContext, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _userManager = userManager;

        }

        public IActionResult Index(string? message)
        {
            ViewBag.Message = message;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            return View(_orderRepository.GetUserOrders(userId));
        }

        public IActionResult OrderDetails(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }

            var order = _orderRepository.GetOrderById(id);
            var orderItems = _orderItemRepository.GetOrderItemsByOrderId(id);
            ViewBag.OrderItems = orderItems;

            if (order == null)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes");
            }
            ViewBag.User = _orderRepository.GetUserFromId(order.UserId);
            decimal count = 0;
            foreach (var item in orderItems)
            {
                count += item.Price * item.Quantity;
            }
            order.Total = count;
            ViewBag.TotalPrice = count;

            return View(order);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        //public IActionResult Index(string filter, string orderBy, int perPage)
        //{
        //    var products = _productRepository.GetProducts();
        //    if (filter != null)
        //    {
        //        orderBy = "asc";
        //        perPage = 100;
        //        products = _productRepository.QueryStringFilterProducts(filter, orderBy, perPage);
        //        return View(products);
        //    }
        //    return View(products);
        //}


        public IActionResult Product(int? categoryId, string filter, string orderBy, int perPage)
        {
            List<Product> products = _dbContext.Product.ToList();

            if (categoryId != null)
            {
                products =
                    (
                        from product in _dbContext.Product
                        join proCat in _dbContext.ProductCategory on product.Id equals proCat.ProductId
                        where proCat.CategoryId == categoryId
                        select new Product
                        {
                            Id = product.Id,
                            ProductName = product.ProductName,
                            ProductDescription = product.ProductDescription,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            ProductImage = product.ProductImage
                        }
                    ).ToList();
            }

            ViewBag.Categories = _dbContext.Category.Select
                (
                    c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.CategoryName

                    }
                );

            if (filter != null)
                    {
                        orderBy = "asc";
                        perPage = 100;
                        products = _productRepository.QueryStringFilterProducts(filter, orderBy, perPage);
                        return View(products);
                    }

                return View(products);
        }


        [Authorize]
        public IActionResult Order(List<string> errors)
        {
            List<CartItem> cartItems = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName) ?? new List<CartItem>();

            if (cartItems.Count == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            decimal sum = 0;
            ViewBag.TotalPrice = cartItems.Sum(item => sum + item.GetTotal());
            ViewBag.Errors = errors;

            return View(cartItems);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            List<CartItem> cartItems = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName) ?? new List<CartItem>();
            if (cartItems.Count == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            List<string> modelErrors = new List<string>();
            if (ModelState.IsValid)
            {
                order.DateCreated = DateTime.Now;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
                order.UserId = userId;

                _dbContext.Order.Add(order);
                _dbContext.SaveChanges();

                int orderId = order.Id;

                foreach (var cartItem in cartItems)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = orderId,
                        ProductId = cartItem.Product.Id,
                        Quantity = cartItem.Quantity,
                        Total = cartItem.GetTotal(),
                        Price = cartItem.Product.Price
                    };

                    _dbContext.OrderItem.Add(orderItem);
                    _dbContext.SaveChanges();
                }

                HttpContext.Session.SetObjectAsJson(_sessionKeyName, "");
                return RedirectToAction(nameof(Index), new { message = "Thank you for your order!" });
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction(nameof(Order), new { errors = modelErrors });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

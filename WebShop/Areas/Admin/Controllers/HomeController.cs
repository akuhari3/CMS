using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin"), Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAdministrationRepository _administrationRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;


        public HomeController(ILogger<HomeController> logger, IAdministrationRepository administrationRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _administrationRepository = administrationRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("SuperAdmin"))

            {
                ViewBag.CountUsers = _administrationRepository.CountUsers();
                ViewBag.CountRoles = _administrationRepository.CountRoles();
            }

            ViewBag.CountProducts = _productRepository.CountProducts();
            ViewBag.CountCategories = _categoryRepository.CountCategories();

            ViewBag.CountOrders = _orderRepository.CountOrders();
            ViewBag.OrdersTotal = _orderRepository.OrdersTotal();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
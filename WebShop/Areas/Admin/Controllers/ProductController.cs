using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin"), Area("Admin")]
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Product Action Methods

        public IActionResult Index()
        {
            return View(_productRepository.GetProducts());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes", new { source = "Id is not valid!" });
            }

            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("PageNotFound", "HttpStatusCodes", new { source = "No products in database!" });
            }

            return View(product);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.up(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _productRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            var category = _productRepository.GetCategoryById(id);
            _productRepository.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }


        #endregion
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [Authorize(Roles = "SuperAdmin, Admin, Operater")]
        public IActionResult Index(string filter, int perPage, int categoryId)
        {
            var products = _productRepository.GetProducts();
            ViewBag.Products = products.Count();

            if (filter != null || perPage > 0)
            {
                products = _productRepository.QueryStringFilterProducts(filter, perPage, categoryId);
                return View(products);
            }
            return View(products);
        }
        [Authorize(Roles = "SuperAdmin, Admin, Operater")]
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
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                string fileName = ProcessUploadedFile(product);
                _productRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            ProductViewModel productViewModel = new ProductViewModel()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Quantity = product.Quantity

            };

            if (product.ProductImage != null)
            {
                ProcessUploadedFile(productViewModel);
            }

            return View(productViewModel);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                ProcessUploadedFile(product);
                _productRepository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            var category = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region File Management

        private string ProcessUploadedFile(ProductViewModel model)
        {
            string fileName = null;
            if (model.ProductImage != null)
            {
                fileName = _productRepository.UploadFile(model);
            }
            return fileName;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [ActionName("DeleteProductPhoto")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductPhoto(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product.ProductImage != null)
            {
                var pvm = _productRepository.DeleteFile(product);
                _productRepository.UpdateProduct(pvm);
            }
            return RedirectToAction("Details", new { id = product.Id });

        }

        #endregion
    }
}

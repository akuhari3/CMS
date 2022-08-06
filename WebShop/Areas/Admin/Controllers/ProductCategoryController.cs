using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin"), Area("Admin")]
    public class ProductCategoryController : Controller
    {
        #region Fields

        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region Constructors

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, ICategoryRepository categoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Product Category Action Methods

        public IActionResult Index(int productId)
        {

            var productCategories = _productCategoryRepository.GetProductCategories(productId);

            ViewBag.ProductId = productId;

            return View(productCategories);
        }

        public IActionResult Create(int productId)
        {
            ViewBag.ProductId = productId;
            ViewBag.Categories = _categoryRepository.CategoriesForDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _productCategoryRepository.AddProductCategory(productCategory);
                return RedirectToAction(nameof(Index), new { productId = productCategory.ProductId });
            }

            return View(productCategory);
        }

        public IActionResult Edit(int id)
        {
            var productCategory = _productCategoryRepository.GetProductCategoryById(id);
            ViewBag.Categories = _categoryRepository.CategoriesForDropDownList();

            return View(productCategory);
        }

        [HttpPost]
        public IActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _productCategoryRepository.UpdateProductCategory(productCategory);
                return RedirectToAction(nameof(Index), new { productId = productCategory.ProductId });
            }

            return View(productCategory);
        }

        public IActionResult Delete(int id)
        {
            var productCategory = _productCategoryRepository.GetProductCategoryById(id);

            return View(productCategory);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteProductCategory(int id)
        {
            var productCategory = _productCategoryRepository.GetProductCategoryById(id);
            _productCategoryRepository.DeleteProductCategory(productCategory);

            return RedirectToAction(nameof(Index), new { productId = productCategory.ProductId });
        }

        #endregion
    }
}

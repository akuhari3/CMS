using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin"), Area("Admin")]
    public class CategoryController : Controller
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors

        public CategoryController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Category Action Methods

        public IActionResult Index()
        {
            return View(_categoryRepository.GetCategories());
        }

        public IActionResult Details(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, CategoryName, CategoryDescription, CategoryImage")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                ProcessUploadedFile(category);
                _categoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                
            };

            if(category.CategoryImage != null)
            {
                ProcessUploadedFile(categoryViewModel);
            }

            return View(categoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                ProcessUploadedFile(category);
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            _categoryRepository.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region File Management

        private string ProcessUploadedFile(CategoryViewModel model)
        {
            string fileName = null;
            if (model.CategoryImage != null)
            {
                fileName = _categoryRepository.UploadFile(model);
            }
            return fileName;
        }

        [HttpPost]
        [ActionName("DeleteCategoryPhoto")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPhoto(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category.CategoryImage != null)
            {
                var cvm = _categoryRepository.DeleteFile(category);
                _categoryRepository.UpdateCategory(cvm);
            }
            return RedirectToAction("Details", new { id = category.Id });

        }
        #endregion
    }
}

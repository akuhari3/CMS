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
    [Authorize(Roles = "Admin"), Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CategoryController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetCategories());
        }

        public IActionResult Details(int id)
        {
            var category = _productRepository.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, CategoryName, CategoryDescription")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _productRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateCategory(category);
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

    }
}

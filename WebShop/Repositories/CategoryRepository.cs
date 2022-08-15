using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructors
        public CategoryRepository(ApplicationDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Category Repository Implementation

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Category.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(p => p.Id == id);
            return category;
        }

        public void AddCategory(CategoryViewModel category)
        {

            Category cat = new Category()
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
            };

            if (category.CategoryImage != null)
            {
                cat.CategoryImage = category.CategoryImage.FileName;
            }


            _dbContext.Category.Add(cat);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(CategoryViewModel categoryVM)
        {
            var category = _dbContext.Category.FirstOrDefault(a => a.Id == categoryVM.Id);

            category.Id = categoryVM.Id;
            category.CategoryName = categoryVM.CategoryName;
            category.CategoryDescription = categoryVM.CategoryDescription;


            if (categoryVM.CategoryImage != null)
            {
                category.CategoryImage = categoryVM.CategoryImage.FileName;
            }

            _dbContext.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {

            var category = _dbContext.Category.Find(id);
            if (category != null)
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public int CountCategories()
        {
            return _dbContext.Category.Count();
        }

        #endregion

        #region Categories DDL

        public List<SelectListItem> CategoriesForDropDownList()
        {
            return _dbContext.Category.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();
        }

        #endregion

        #region File Management

        public string UploadFile(CategoryViewModel model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "categories");
            var fileName = model.CategoryImage.FileName;
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.CategoryImage.CopyTo(fileStream);
            }
            return fileName;
        }

        public CategoryViewModel DeleteFile(Category category)
        {
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "categories", category.CategoryImage);
            System.IO.File.Delete(filePath);
            category.CategoryImage = null;
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };
            return cvm;
        }

        #endregion
    }
}

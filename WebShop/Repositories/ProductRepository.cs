using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Product Repository Implementation

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
        }

        //edit, delete

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

        public void AddCategory(Category category)
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
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

        #endregion

        #region Product Category Repository Implementation

        public IEnumerable<ProductCategory> GetProductCategories(int id)
        {
            var productCategories = (from prodCat in _dbContext.ProductCategory
                                     where prodCat.ProductId == id
                                     select new ProductCategory
                                     {
                                         Id = prodCat.Id,
                                         ProductId = prodCat.ProductId,
                                         ProductTitle = (from p in _dbContext.Product where p.Id == prodCat.ProductId select p.ProductName).FirstOrDefault(),
                                         CategoryId = prodCat.CategoryId,
                                         CategoryTitle = (from c in _dbContext.Category where c.Id == prodCat.CategoryId select c.CategoryName).FirstOrDefault()
                                     }).ToList();

            return productCategories;
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            var productCategory = _dbContext.ProductCategory.FirstOrDefault(p => p.Id == id);
            return productCategory;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _dbContext.ProductCategory.Add(productCategory);
            _dbContext.SaveChanges();
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            _dbContext.ProductCategory.Update(productCategory);
            _dbContext.SaveChanges();
        }

        public void DeleteProductCategory(ProductCategory productCategory)
        {
            _dbContext.ProductCategory.Remove(productCategory);
            _dbContext.SaveChanges();
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
    }
}

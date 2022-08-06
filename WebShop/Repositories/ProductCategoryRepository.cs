using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public ProductCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
            productCategory.CategoryTitle = _dbContext.Category.FirstOrDefault(c => c.Id == productCategory.CategoryId).CategoryName;
            productCategory.ProductTitle = _dbContext.Product.FirstOrDefault(c => c.Id == productCategory.ProductId).ProductName;
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
    }
}

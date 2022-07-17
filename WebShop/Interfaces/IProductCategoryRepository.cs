using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductCategories(int id);
        ProductCategory GetProductCategoryById(int id);
        void AddProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        public void DeleteProductCategory(ProductCategory productCategory);
    }
}

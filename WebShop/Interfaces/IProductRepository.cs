using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;

namespace WebShop.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

        IEnumerable<ProductCategory> GetProductCategories(int id);
        ProductCategory GetProductCategoryById(int id);
        void AddProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        public void DeleteProductCategory(ProductCategory productCategory);
        List<SelectListItem> CategoriesForDropDownList();

    }
}

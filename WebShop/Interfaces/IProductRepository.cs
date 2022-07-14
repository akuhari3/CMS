using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(ProductViewModel product);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(CategoryViewModel category);
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

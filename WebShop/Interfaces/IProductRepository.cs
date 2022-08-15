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
        Product UpdateProduct(ProductViewModel product);
        void DeleteProduct(int id);
        string UploadFile(ProductViewModel model);
        ProductViewModel DeleteFile(Product product);
        int CountProducts();
        List<SelectListItem> GetProductsForDropDownList();
        List<Product> GetAllAPI();
        Product GetProductByIdAPI(int id);
        Product InsertProductAPI(Product product);
        Product UpdateProductAPI(Product product);
        void DeleteProductAPI(int id);
        List<Product> QueryStringFilterAPI(string s);
        List<Product> QueryStringFilterProducts(string s);

    }
}

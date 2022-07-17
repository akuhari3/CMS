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
        void UpdateProduct(ProductViewModel product);
        void DeleteProduct(int id);
        string UploadFile(ProductViewModel model);
        ProductViewModel DeleteFile(Product product);
    }
}

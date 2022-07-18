using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public ProductRepository(ApplicationDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
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

        public void AddProduct(ProductViewModel product)
        {
            Product p = new Product()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Quantity = product.Quantity,

            };

            if (product.ProductImage != null)
            {
                p.ProductImage = product.ProductImage.FileName;
            }


            _dbContext.Product.Add(p);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductViewModel productVM)
        {
            Product product = new Product()
            {
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                Price = productVM.Price,
                Quantity = productVM.Quantity
            };
            var image = _dbContext.Product.FirstOrDefault(a => a.Id == productVM.Id);

            if (productVM.ProductImage != null)
            {
                product.ProductImage = productVM.ProductImage.FileName;
            }

            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {

            var product = _dbContext.Product.Find(id);
            if (product != null)
            {
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        #endregion

        #region File Management
        public string UploadFile(ProductViewModel model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "products");
            var fileName = model.ProductImage.FileName;
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.ProductImage.CopyTo(fileStream);
            }

            return fileName;
        }

        public ProductViewModel DeleteFile(Product product)
        {
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "products", product.ProductImage);
            System.IO.File.Delete(filePath);
            product.ProductImage = null;
            ProductViewModel pvm = new ProductViewModel()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                Quantity = product.Quantity
            };
            return pvm;
        }

        #endregion

        #region DropDownList Product
        public List<SelectListItem> GetProductsForDropDownList()
        {
            return _dbContext.Product.Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.ProductName

            }).ToList();

        }

        #endregion
    }
}

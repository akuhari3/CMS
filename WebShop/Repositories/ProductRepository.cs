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

        public Product UpdateProduct(ProductViewModel productVM)
        {
            var product = _dbContext.Product.FirstOrDefault(a => a.Id == productVM.Id);

            product.Id = productVM.Id;
            product.ProductName = productVM.ProductName;
            product.ProductDescription = productVM.ProductDescription;
            product.Price = productVM.Price;
            product.Quantity = productVM.Quantity;
            

            if (productVM.ProductImage != null)
            {
                product.ProductImage = productVM.ProductImage.FileName;
            }

            _dbContext.Update(product);
            _dbContext.SaveChanges();

            return product;
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

        public int CountProducts()
        {
            return _dbContext.Product.Count();
        }

        #endregion

        #region Product API Repository Implementation

        public List<Product> GetAllAPI()
        {
            return _dbContext.Product.ToList();
        }

        public Product GetProductByIdAPI(int id)
        {
            return _dbContext.Product.FirstOrDefault(m => m.Id == id);
        }

        public Product InsertProductAPI(Product product)
        {
            var result = _dbContext.Product.Add(product);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Product UpdateProductAPI(Product product)
        {
            var result = _dbContext.Product.FirstOrDefault(m => m.Id == product.Id);

            if (result != null)
            {
                result.ProductName = product.ProductName;
                result.ProductDescription = product.ProductDescription;
                result.Quantity = product.Quantity;
                result.Price = product.Price;
                result.ProductImage = product.ProductImage;

                _dbContext.SaveChanges();

                return result;
            }

            return null;
        }

        public void DeleteProductAPI(int id)
        {
            var result = _dbContext.Product.FirstOrDefault(m => m.Id == id);

            if (result != null)
            {
                _dbContext.Product.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public List<Product> QueryStringFilterAPI(string s, int perPage)
        {
            var filter = _dbContext.Product.ToList();

            if (!string.IsNullOrEmpty(s))
            {
                filter = filter
                    .Where
                    (
                        p => p.ProductName.Contains(s, StringComparison.CurrentCultureIgnoreCase)
                        || p.ProductDescription.Contains(s, StringComparison.CurrentCultureIgnoreCase)
                    ).ToList();
            }

            return filter;
        }

        public List<Product> QueryStringFilterProducts(string s, int perPage, int categoryId)
        {
            var filter = _dbContext.Product.ToList();

            if (!string.IsNullOrEmpty(s))
            {
                filter = filter
                    .Where
                    (
                        p => p.ProductName.Contains(s, StringComparison.CurrentCultureIgnoreCase)
                        || p.ProductDescription.Contains(s, StringComparison.CurrentCultureIgnoreCase)
                    ).ToList();
            }

            if (categoryId != 0)
            {
                filter =
                    (
                        from product in _dbContext.Product
                        join proCat in _dbContext.ProductCategory on product.Id equals proCat.ProductId
                        where proCat.CategoryId == categoryId
                        select new Product
                        {
                            Id = product.Id,
                            ProductName = product.ProductName,
                            ProductDescription = product.ProductDescription,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            ProductImage = product.ProductImage
                        }

                    ).ToList();
            }

            if (perPage > 0)
            {
                filter = filter.Take(perPage).ToList();
            }

            return filter;
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
                Id = product.Id,
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

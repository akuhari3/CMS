using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        #region Fields
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        #endregion

        #region Product API Action Methods

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            try
            {
                return Ok(_productRepository.GetAllAPI());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                var result = _productRepository.GetProductByIdAPI(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPut("{id}")]
        public ActionResult PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest("Product Id missmatch");
                }

                var productForUpdating = _productRepository.GetProductByIdAPI(id);
                if (productForUpdating == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                var updatedProduct = _productRepository.UpdateProductAPI(product);

                return Ok(updatedProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpPost]
        public ActionResult PostProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdProduct = _productRepository.InsertProductAPI(product);

                return CreatedAtAction
                    (
                        nameof(GetProduct), new { id = createdProduct.Id },
                        createdProduct
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var productToDelete = _productRepository.GetProductByIdAPI(id);
                if (productToDelete == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                _productRepository.DeleteProductAPI(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpGet("search")]
        public ActionResult SearchByQueryString([FromQuery] string s, [FromQuery] string orderBy = "asc", [FromQuery] int perPage = 0)
        {
            try
            {
                var products = _productRepository.QueryStringFilterAPI(s, orderBy, perPage);

                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        #endregion
    }
}

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
        #endregion
    }
}

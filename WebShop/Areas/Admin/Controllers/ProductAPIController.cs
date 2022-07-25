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

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            try
            {
                return Ok(_productRepository.GetProducts());
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
                var result = _productRepository.GetProductById(id);
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

                var productForUpdating = _productRepository.GetProductById(id);
                if (productForUpdating == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                var updatedProduct = _productRepository.UpdateProduct(product);

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

                var createdMovie = _productRepository.AddProduct(product);

                return CreatedAtAction
                    (
                        nameof(GetProduct), new { id = createdProduct.Id },
                        createdMovie
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            try
            {
                var movieToDelete = _movieRepository.GetMovieById(id);
                if (movieToDelete == null)
                {
                    return NotFound($"Movie with Id = {id} not found");
                }

                _movieRepository.DeleteMovie(id);

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
                var movies = _movieRepository.QueryStringFilter(s, orderBy, perPage);

                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }


    }
}

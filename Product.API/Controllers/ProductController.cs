using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Entities.Product> Get()
        {
            return _dbContext.Products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Entities.Product Get(int id)
        {
            return _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Entities.Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entities.Product product)
        {
            try
            {
                if (product == null || id <= 0 || product.Id != id)
                {
                    return BadRequest("Invalid product data.");
                }
                else
                {
                    var existingProduct = _dbContext.Products.Find(id);
                    if (existingProduct == null)
                    {
                        return NotFound($"Product with ID {id} not found.");
                    }
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Description = product.Description;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.ImageUrl = product.ImageUrl;
                    _dbContext.Products.Update(existingProduct);
                    _dbContext.SaveChanges();
                    return Ok(existingProduct);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return BadRequest("Invalid product data.");
                }
                var product = _dbContext.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return Ok($"Product with ID {id} has been deleted.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }
    }
}

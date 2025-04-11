using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSApi.Data;
using POSApi.Models.Entities;

namespace POSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public ProductController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_dbContext.Products.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpPost]
        public IActionResult AddProduct(ProductDTO productDTO)
        {
            var productEntity = new Product()
            {
                ProductName = productDTO.ProductName,
                Price = productDTO.Price
            };

            _dbContext.Products.Add(productEntity);
            _dbContext.SaveChanges();
            return Ok(productEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = _dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            product.ProductName = productDTO.ProductName;
            product.Price = productDTO.Price;

            _dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

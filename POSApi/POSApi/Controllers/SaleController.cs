using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSApi.Data;
using POSApi.Models.Entities;

namespace POSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public SaleController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSaleInfo()
        {
            return Ok(_dbContext.Sales.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSaleBySaleId(int id)
        {
            var sale = _dbContext.Sales.Find(id);

            if (sale is null)
            {
                return NotFound();
            }
            return Ok(sale);

        }

        [HttpPost]
        public IActionResult Sale(SaleDTO saleDTO)
        {
            var saleEntity = new Sale()
            {
                ProductId = saleDTO.ProductId,
                CustomerId = saleDTO.CustomerId,
                SaleDate = DateTime.UtcNow,
                Quantity = saleDTO.Quantity,
                TotalPrice = saleDTO.TotalPrice,
            };

            _dbContext.Sales.Add(saleEntity);
            _dbContext.SaveChanges();
            return Ok(saleEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateSale(int id, SaleDTO saleDTO)
        {
            var sale = _dbContext.Sales.Find(id);
            if (sale is null)
            {
                return NotFound();
            }
            sale.ProductId = saleDTO.ProductId;
            sale.CustomerId = saleDTO.CustomerId;
            sale.SaleDate = DateTime.UtcNow;
            sale.Quantity = saleDTO.Quantity;
            sale.TotalPrice = saleDTO.TotalPrice;


            _dbContext.SaveChanges();
            return Ok(sale);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = _dbContext.Sales.Find(id);
            if (sale is null)
            {
                return NotFound();
            }

            _dbContext.Sales.Remove(sale);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

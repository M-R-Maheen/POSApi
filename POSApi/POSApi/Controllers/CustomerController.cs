using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSApi.Data;
using POSApi.Models.Entities;

namespace POSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_dbContext.Customers.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _dbContext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddCustomerDTO addCustomerDTO)
        {
            var customerEntity = new Customer()
            {
                FullName = addCustomerDTO.FullName,
                Email = addCustomerDTO.Email,
            };

            _dbContext.Customers.Add(customerEntity);
            _dbContext.SaveChanges();
            return Ok(customerEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.FullName = updateCustomerDTO.FullName;
            

            _dbContext.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

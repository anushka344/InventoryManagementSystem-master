using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dbContext.Customers;
        }
        
                // GET: api/Customer/{id}
                [HttpGet("{id}")]
                public IActionResult Get(int id)
                {
                    var cust = _dbContext.Customers.FirstOrDefault(s => s.Id == id);
                    if (cust == null)
                    {
                        return NotFound();
                    }

                    return Ok(cust);
                }

                // POST: api/Supplier
                [HttpPost]
                public IActionResult Post([FromBody] Customer customer)
                {

                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();

                    return Ok("Customer created successfully");
                }

                // PUT: api/Customer/{id}
                [HttpPut("{id}")]
                public IActionResult Put(int id, [FromBody] Customer customerObj)
                {
                    var customer = _dbContext.Customers.FirstOrDefault(s => s.Id == id);
                    if ( customer == null)
                    {
                        return NotFound("Data not found against Id " + id);
                    }
                    customer.Name = customerObj.Name;
                    customer.Address = customerObj.Address;
                    customer.PhoneNumber = customerObj.PhoneNumber;
                    customer.State = customerObj.State;

                    _dbContext.SaveChanges();

                    return Ok("customer data updated successfully");
                }

                // DELETE: api/Customer/{id}
                [HttpDelete("{id}")]
                public IActionResult Delete(int id)
                {
                    var customer = _dbContext.Customers.FirstOrDefault(s => s.Id == id);
                    if (customer  == null)
                    {
                        return NotFound("No customer with id " + id + " found.");
                    }

                    _dbContext.Customers.Remove(customer);
                    _dbContext.SaveChanges();

                    return Ok("customer deleted successfully");
                } 
    }
}


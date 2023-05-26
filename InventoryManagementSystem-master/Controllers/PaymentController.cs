using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private ApiDbContext _dbContext = new ApiDbContext();
        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return _dbContext.Payments;
                
        }


        // POST: api/Payment
        [HttpPost]
        public IActionResult Create([FromBody] Payment payment)
        {
            var product = _dbContext.Products.Find(payment.ProductId);
            if (product == null)
            {
                return NotFound("Invalid product ID");
            }

            if (product.ProductQuantity < payment.Qty)
            {
                return BadRequest("Insufficient product quantity");
            } 

            var customer = _dbContext.Customers.Find(payment.CustomerId);
            if (customer == null)
            {
                return NotFound("Invalid customer ID");
            }

            product.ProductQuantity -= payment.Qty;

            _dbContext.Payments.Add(payment);
       
            _dbContext.SaveChanges();

            return Ok("Data added successfully");
        }
       

             // DELETE api/<PaymentController>/5
             [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var existingPayment = _dbContext.Payments.Find(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            _dbContext.Payments.Remove(existingPayment);
            _dbContext.SaveChanges();

            return Ok("Payment deleted successfully");
        }
    }
}

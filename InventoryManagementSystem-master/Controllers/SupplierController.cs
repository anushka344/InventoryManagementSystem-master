
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ApiDbContext _dbContext = new ApiDbContext();

        // GET: api/Supplier
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _dbContext.Suppliers;
        }

        // GET: api/Supplier/{id}
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            var supplier = _dbContext.Suppliers.FirstOrDefault(s => s.Id == id);
            return supplier;
        }

        // POST: api/Supplier
        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            var country = _dbContext.Countries.FirstOrDefault(c => c.Id == supplier.CountryId);
            if (country == null)
            {
                return NotFound($"CountryId {supplier.CountryId} does not exist.");
            }

            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();

            return Ok("Supplier created successfully");
        }

        // PUT: api/Supplier/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Supplier supplierObj)
        {
            var supplier = _dbContext.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound("Data not found against Id " + id);
            }

            supplier.Name = supplierObj.Name;
            supplier.Address = supplierObj.Address;
            supplier.PhoneNumber = supplierObj.PhoneNumber;
            supplier.State = supplierObj.State;
            supplier.CountryId = supplierObj.CountryId;
            _dbContext.SaveChanges();

            return Ok("Supplier data updated successfully");
        }

        // DELETE: api/Supplier/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supplier = _dbContext.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound("No supplier with id " + id + " found.");
            }

            _dbContext.Suppliers.Remove(supplier);
            _dbContext.SaveChanges();

            return Ok("Supplier deleted successfully");
        }
    }
}

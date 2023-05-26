
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ApiDbContext _dbContext = new ApiDbContext();

        
        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _dbContext.Countries;
        }

        // GET: api/Country/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var country = _dbContext.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST: api/Country
        [HttpPost]
      
        public IActionResult Post([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return Ok("Data added successfully");

        }
      

        // PUT: api/Country/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country countryObj)
        {
            var country = _dbContext.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound("Data not found against Id " + id);
            }

            country.CountryName = countryObj.CountryName;
            country.CountryCode = countryObj.CountryCode;
            _dbContext.SaveChanges();

            return Ok("Data updated successfully");
        }

        // DELETE: api/Country/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = _dbContext.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound("No id present as such " + id);
            }

            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();

            return Ok("Data deleted successfully");
        }
    }
}

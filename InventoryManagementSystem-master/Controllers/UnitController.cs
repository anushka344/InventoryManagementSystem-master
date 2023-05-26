using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;



namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();
        // GET: api/<UnitController>
        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return _dbContext.Units;
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public Unit Get(int id)
        {
            var units = _dbContext.Units.FirstOrDefault(c => c.Id == id);
            return units;
        }
        // POST api/<UnitController>
        [HttpPost]
        public IActionResult Post([FromBody] Unit units)
        {
            _dbContext.Units.Add(units);
            _dbContext.SaveChanges();
            return Ok("Data is added");

        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Unit unitObj)
        {

            var unit = _dbContext.Units.Find(id);
            if (unit == null)
            {
                return NotFound("Data not found against Id " + id);
            }
            else
            {
             unit.Name = unitObj.Name;
                unit.Description= unitObj.Description;
                _dbContext.SaveChanges();
                return Ok("Data updated successfully");
            }

        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var unit = _dbContext.Units.Find(id);
            if (unit == null)
            {
                return NotFound("No id present as such " + id);
            }
            else
            {
                _dbContext.Units.Remove(unit);
                _dbContext.SaveChanges();
                return Ok("Data deleted successfully");
            }


        }


    }
}

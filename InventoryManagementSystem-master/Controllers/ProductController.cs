
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApiDbContext _dbContext = new ApiDbContext();
        private UnitController _unitController = new UnitController();
        private SupplierController _supplierController = new SupplierController();

        // GET: api/Product
        [HttpGet]
            public IEnumerable<Product> Get()
            {
                return _dbContext.Products;
            }


      //   GET api/Product/5
         [HttpGet("{id}")]
         public Product Get(int id)
         {
             var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
             return product;
         }


       
        // POST api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var unit = _unitController.Get(product.UnitId);
            if (unit == null)
            {
                return NotFound($"Product Id {product.UnitId} not found");
            }
            var supp = _supplierController.Get(product.SupplierId);
            if(supp == null)
            {
                return NotFound($"Supplier Id {product.SupplierId} not found");
            }


            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }


        // PUT api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product productObj)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound("Data not found against Id " + id);
            }

            var unit = _unitController.Get(productObj.UnitId);
            if (unit == null)
            {
                return NotFound($"Product Id {productObj.UnitId} not found");
            }
            var supp = _supplierController.Get(productObj.SupplierId);
            if(supp == null)
            {
                return NotFound($"Supplier Id {product.SupplierId} not found");
            }

            product.Name = productObj.Name;
            product.Brand = productObj.Brand;
            product.ProductQuantity = productObj.ProductQuantity; 
            product.UnitId = productObj.UnitId;
         //   product.UnitName = unit.Name;

            _dbContext.SaveChanges();
            return Ok("Data updated successfully");
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound("No id present as such in Units" + id);
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return Ok("Data deleted successfully");
        }
    }
}

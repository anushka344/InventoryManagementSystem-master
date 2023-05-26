using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Unit Name cannot be null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        public string Description { get; set; }

        public  ICollection<Product> Products { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Brand cannot be empty")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Quantity cannot be null")]
        public int ProductQuantity { get; set; }
        public int UnitId { get; set; } //foreign key
        public Unit Unit { get; set; }
        public int SupplierId {  get; set; }
        public Supplier Supplier { get; set; }

        // Navigation property
        public ICollection<Payment> Payments { get; set; }

    }
}

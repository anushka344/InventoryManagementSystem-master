
using System.ComponentModel.DataAnnotations;
namespace InventoryManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field cannot be null")]
        public DateTime  PaymentDate { get; set; }

        [Required(ErrorMessage = "Field cannot be null")]

        public int Qty { get; set; }
        public int CustomerId { get; set; } //foreign key from customer table

        public int ProductId { get; set; } //foreign key from product table
        //public int ProductQuantity { get; set; } //foreign key from product table

        // Navigation properties
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
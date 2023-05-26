using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address cannot be null")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number cannot be null")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "State cannot be null")]
        public string State { get; set; }
        // Navigation property
        public ICollection<Payment> Payments { get; set; }


    }
}



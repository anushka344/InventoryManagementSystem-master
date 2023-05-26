using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Country
    {
        
         public int Id { get; set; }

        [Required(ErrorMessage = "Country code cannot be null")]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = "Country Name cannot be null")]
        public string CountryName { get; set; }

         public ICollection<Supplier> Suppliers { get; set; }
        

}
}

using System.ComponentModel.DataAnnotations;

namespace LnP_Infotech_ujjwal_Kumar.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

  
        public ICollection<ProductCategory> ProductCategories { get; set; }
            = new List<ProductCategory>();
    }

}

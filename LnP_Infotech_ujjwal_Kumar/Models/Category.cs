using System.ComponentModel.DataAnnotations;

namespace LnP_Infotech_ujjwal_Kumar.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

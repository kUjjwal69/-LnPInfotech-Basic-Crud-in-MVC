using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LnP_Infotech_ujjwal_Kumar.Models
{
    public class ProductCategory
    {
        [Key]
            public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

            public Product Product { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

            public Category Category { get; set; }
        }

 
}

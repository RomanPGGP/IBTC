using System.ComponentModel.DataAnnotations;

namespace CAIBT.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

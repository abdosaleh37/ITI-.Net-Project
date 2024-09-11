using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_Project.Models
{
    public class Product
    { 
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Title is required!")]
        [DisplayName("Product title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [DisplayName("Product price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [DisplayName("Product description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        [DisplayName("Product quantity")]
        public int Quantity { get; set; }

        public string? ImagePath { get; set; }

        public int CategoryId {  get; set; }

        public virtual Category Category { get; set; }
    }
}

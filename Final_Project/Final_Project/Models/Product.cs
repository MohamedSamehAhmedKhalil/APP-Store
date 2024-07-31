using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Final_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Name Of Product")]
        [Required(ErrorMessage = "you have to provide a valid name.")]
        [MinLength(3, ErrorMessage = "Full name mustn't be less than 3 characters.")]
        [MaxLength(80, ErrorMessage = "Full name mustn't exceepd 80 characters.")]
        public string Name { get; set; }

        [DisplayName("Color / Type")]
        [Required(ErrorMessage = "you have to provide a valid Color or Type of product.")]
        [MinLength(3, ErrorMessage = "Color mustn't be less than 3 characters.")]
        [MaxLength(40, ErrorMessage = "Color mustn't exceepd 40 characters.")]
        public string Color { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "you have to provide a Price of product.")]
        [Range(3000, 35000, ErrorMessage = "Price must be between 3000 and 35000.")]
        public decimal Price { get; set; }

        [DisplayName("Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [DisplayName("Date of Join")]
        public DateTime JoinDate { get; set; }

        //Navigation Property
        [ValidateNever]
        public List<Order> Orders { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Final_Project.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "you have to provide a valid full name.")]
        [MinLength(10, ErrorMessage = "Full name mustn't be less than 12 characters.")]
        [MaxLength(70, ErrorMessage = "Full name mustn't exceepd 70 characters.")]
        public string Name { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "You have to provide a valid Address.")]
        [MinLength(15, ErrorMessage = "min 2 characters.")]
        [MaxLength(50, ErrorMessage = "max 20 characters.")]
        public string Address { get; set; }

        [DisplayName("Mobile")]
        [Required(ErrorMessage = "You have to provide a valid Mobile Number.")]
        [MinLength(11, ErrorMessage = "Mobile Number Mustn't be less than 11 Numbers")]
        [MaxLength(15, ErrorMessage = "Mobile Number Mustn't exceepd 15 Numbers")]
        public string Mobile { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "You have to provide a valid Email.")]
        [MaxLength(50)]
        public string Email { get; set; }

        [DisplayName("Date of Join")]
        public DateTime JoinDate { get; set; }


        //Navigation Property
        [ValidateNever]
        public List<Order> Orders { get; set; }
    }
}

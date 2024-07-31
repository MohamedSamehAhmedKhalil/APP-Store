using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Order
    {
        public int Id { get; set; }

        //Foreign Key Property
        [DisplayName("Customer")]
        [Required(ErrorMessage = "you have to provide a valid Customer Id.")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a valid Customer.")]
        public int CustomerId { get; set; }

        //Navigation Property
        [ValidateNever]
        public Customer Customer { get; set; }


        //Foreign Key Property
        [DisplayName("Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a valid Product.")]
        [Required(ErrorMessage = "you have to provide a valid Product Id.")]
        public int ProductId { get; set; }

        //Navigation Property
        [ValidateNever]
        public Product Product { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "you have to provide a valid Quantity.")]
        public int Quantity { get; set; }


        [DisplayName("Order Date")]
        [Required(ErrorMessage = "you have to provide a valid Order Date.")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Shipped Date")]
        public DateTime ShippedDate { get; set; }

       
       
    }
}

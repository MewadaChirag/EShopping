using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Order Number")]
        public string  OrderNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}

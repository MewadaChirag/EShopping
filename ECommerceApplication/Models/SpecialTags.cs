using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }
       [Required]
       [Display(Name ="Special Tag")]
        public String SpecialTag { get; set; }
    }
}

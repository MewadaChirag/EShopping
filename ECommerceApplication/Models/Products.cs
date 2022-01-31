namespace ECommerceApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Products
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    
        [Required]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [Display(Name ="Product Color")]
        public string? ProductColor { get; set; }
        
        [Required]
        [ Display(Name ="Available")]
        public bool IsAvailable { get; set; }
        
        [Required]
        [Display(Name = "Product Type")]    
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes? ProductTypes { get; set; }
        
        [Required]
        [Display(Name="Special Tag")]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public SpecialTags? SpecialTags { get; set; }
    }


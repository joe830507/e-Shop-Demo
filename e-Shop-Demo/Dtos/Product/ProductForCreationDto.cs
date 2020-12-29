using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.Product
{
    public class ProductForCreationDto
    {
        [Required]
        [RegularExpression(@"^[\u4e00-\u9fa5a-zA-Z0-9]{1,20}$",
         ErrorMessage = "Your name is not allowed.")]
        public string Name { get; set; }
        [Required]
        [Range(0, 99999999)]
        public double Price { get; set; }
        [Required]
        [Range(0, 99999999)]
        public int Quantity { get; set; }
        [Required]
        public Guid Type { get; set; }
        [RegularExpression(@"^[\u4e00-\u9fa5a-zA-Z0-9]{0,200}$",
         ErrorMessage = "Your description is not allowed.")]
        public string Description { get; set; }
        [Url]
        public string PictureLink { get; set; }
    }
}

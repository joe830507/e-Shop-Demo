using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos
{
    public class SupplierForCreationDto
    {
        [Required]
        [RegularExpression(@"^[\u4e00-\u9fa5_a-zA-Z0-9\s]{1,40}$",
         ErrorMessage = "Your name is not allowed.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^09[0-9\s]{8}$",
         ErrorMessage = "Your phone is not allowed.")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Guid ProductType { get; set; }
    }
}

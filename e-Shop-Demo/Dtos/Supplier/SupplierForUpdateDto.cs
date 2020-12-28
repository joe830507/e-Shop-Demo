using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Shop_Demo.Dtos.Supplier
{
    public class SupplierForUpdateDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [RegularExpression(@"^[\u4e00-\u9fa5_a-zA-Z0-9]{1,40}$",
         ErrorMessage = "Your name is not allowed.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^09[0-9\s]{8}$",
         ErrorMessage = "Your phone is not allowed.")]
        public string Phone { get; set; }
    }
}

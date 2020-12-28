using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.Customer
{
    public class CustomerForUpdateDto
    {
        [Required]
        public Guid ID { get; set; }
        [EmailAddress]
        public string Account { get; set; }
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^(\d){4}-(\d){2}-(\d){2}$",
         ErrorMessage = "Your birthDate is not allowed.")]
        public string BirthDate { get; set; }
        [Range(typeof(bool), "false", " true")]
        public bool Activate { get; set; }
        public string CreateTime { get; set; }
    }
}

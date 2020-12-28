using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.Customer
{
    public class CustomerForCreationDto
    {
        [EmailAddress]
        public string Account { get; set; }
        [Required(ErrorMessage = "Your password is not allowed.")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^(\d){4}-(\d){2}-(\d){2}$",
         ErrorMessage = "Your birthDate is not allowed.")]
        public string BirthDate { get; set; }
        [Range(typeof(bool), "false", " true")]
        public bool Activate { get; set; }
    }
}

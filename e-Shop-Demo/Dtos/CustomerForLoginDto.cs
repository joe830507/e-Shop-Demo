using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos
{
    public class CustomerForLoginDto
    {
        [EmailAddress, Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

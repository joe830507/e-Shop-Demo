using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForLoginDto
    {
        [Key, EmailAddress, Required]
        public string Account { get; set; }
        [MinLength(10), MaxLength(40), Required]
        public string Password { get; set; }
    }
}

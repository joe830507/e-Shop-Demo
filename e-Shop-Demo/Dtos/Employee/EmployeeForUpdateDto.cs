using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForUpdateDto
    {
        [Key, Required]
        public Guid ID { get; set; }
        [EmailAddress, Required(ErrorMessage = "Please write down your account.")]
        public string Account { get; set; }
        public string Password { get; set; }
        [Range(typeof(bool), "false", " true")]
        public bool Activate { get; set; }
        [Range(0, 2)]
        public int Role { get; set; }
    }
}

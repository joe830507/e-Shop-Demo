﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForCreationDto
    {
        [Key, EmailAddress, Required(ErrorMessage = "Please write down your account.")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Please write down your password.")]
        public string Password { get; set; }
        public bool Activate { get; set; }
        public int Role { get; set; }
    }
}

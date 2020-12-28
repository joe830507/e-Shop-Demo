using e_Shop_Demo.Entities;
using System;
using System.Collections.Generic;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForDeleteDto
    {
        public IEnumerable<Guid> Employees { get; set; }

    }
}

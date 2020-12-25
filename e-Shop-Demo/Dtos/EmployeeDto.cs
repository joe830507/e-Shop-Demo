using System;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeDto
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public bool Activate { get; set; }
        public int Role { get; set; }
    }
}

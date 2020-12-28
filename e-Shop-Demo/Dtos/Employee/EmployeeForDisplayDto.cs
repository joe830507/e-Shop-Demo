using System;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForDisplayDto
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public bool Activate { get; set; }
        public string Role { get; set; }
        public string CreateTime { get; set; }
    }
}

using System;

namespace e_Shop_Demo.Dtos
{
    public class SupplierForDisplayDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreateTime { get; set; }
        public Guid ProductType { get; set; }
    }
}

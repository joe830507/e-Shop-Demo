using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.Customer
{
    public class CustomerForDisplayDto
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string BirthDate { get; set; }
        public bool Activate { get; set; }
        public string CreateTime { get; set; }
    }
}

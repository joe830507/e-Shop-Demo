using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos
{
    public class EmployeeForDisplayDto
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string Activate { get; set; }
        public string Role { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
    }
}

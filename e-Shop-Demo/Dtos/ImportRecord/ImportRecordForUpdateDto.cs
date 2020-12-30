using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.ImportRecord
{
    public class ImportRecordForUpdateDto
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Status { get; set; } = 1;
        [Required]
        public double ImportPrice { get; set; }
    }
}

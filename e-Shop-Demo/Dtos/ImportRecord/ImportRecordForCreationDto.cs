using System;
using System.ComponentModel.DataAnnotations;

namespace e_Shop_Demo.Dtos.ImportRecord
{
    public class ImportRecordForCreationDto
    {
        [Required]
        public Guid ProductID { get; set; }
        [Required]
        public Guid SupplierID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Status { get; set; }
        public double ImportPrice { get; set; }
    }
}

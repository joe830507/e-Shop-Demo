﻿using System;
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
        [Range(1, 99999999)]
        public int Quantity { get; set; }
        public int Status { get; set; } = 1;
        [Required]
        [Range(1, 99999999)]
        public double ImportPrice { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}

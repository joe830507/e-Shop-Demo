using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos.ImportRecord
{
    public class ImportRecordForDisplayDto
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public double ImportPrice { get; set; }
        public string CreateTime { get; set; }
    }
}

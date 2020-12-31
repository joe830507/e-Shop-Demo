using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos.PurchaseRecord
{
    public class PurchaseDetailRecordForDisplayDto
    {
        public string ProductName { get; set; }
        public double CurrentPrice { get; set; }
        public int Quantity { get; set; }
    }
}

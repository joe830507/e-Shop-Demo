using e_Shop_Demo.Entities;
using System;
using System.Collections.Generic;

namespace e_Shop_Demo.Dtos.PurchaseRecord
{
    public class PurchaseRecordForDisplayDto
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Total { get; set; }
        public DateTime CreateTime { get; set; }
        public IEnumerable<PurchaseDetailRecord> PurchaseDetailRecords { get; set; }
        public IEnumerable<PurchaseDetailRecordForDisplayDto> DisplayList { get; set; }
    }
}

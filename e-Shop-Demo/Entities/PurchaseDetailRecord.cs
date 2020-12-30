using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Shop_Demo.Entities
{
    public class PurchaseDetailRecord
    {
        [Key]
        [ForeignKey("PurchaseRecord")]
        public Guid PurchaseRecordID { get; set; }
        public virtual PurchaseRecord PurchaseRecord { get; set; }
        [Key]
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public double CurrentPrice { get; set; }
        public int Quantity { get; set; }
    }
}

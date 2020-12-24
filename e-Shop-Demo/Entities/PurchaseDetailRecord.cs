using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Shop_Demo.Entities
{
    public class PurchaseDetailRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("PurchaseRecord")]
        public Guid PurchaseRecordId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public double CurrentPrice { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
    }
}

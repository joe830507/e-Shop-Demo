using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Shop_Demo.Entities
{
    public class PurchaseRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Total { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
        public virtual ICollection<PurchaseDetailRecord> PurchaseDetailRecords { get; set; }
    }
}

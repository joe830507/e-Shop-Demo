using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Shop_Demo.Entities
{
    public class ImportRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        [ForeignKey("Supplier")]
        public Guid SupplierID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public double ImportPrice { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }
    }
}

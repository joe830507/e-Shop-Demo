using System;

namespace e_Shop_Demo.Dtos
{
    public class ProductForDisplayDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public string CreateTime { get; set; }
    }
}

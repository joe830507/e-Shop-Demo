using System;
using System.Collections.Generic;

namespace e_Shop_Demo.Dtos.Product
{
    public class ProductForDeleteDto
    {
        public IEnumerable<Guid> Products { get; set; }
    }
}

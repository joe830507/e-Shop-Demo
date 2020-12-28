using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Dtos.Customer
{
    public class CustomerForDeleteDto
    {
        public IEnumerable<Guid> Customers { get; set; }
    }
}

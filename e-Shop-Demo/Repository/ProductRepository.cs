using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class ProductRepository : RepositoryBase<Product, Guid>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

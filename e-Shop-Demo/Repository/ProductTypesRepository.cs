using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_Shop_Demo.Repository
{
    public class ProductTypesRepository : RepositoryBase<ProductType, Guid>
    {
        public ProductTypesRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

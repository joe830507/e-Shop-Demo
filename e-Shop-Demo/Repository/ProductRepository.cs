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

        public void DeleteProducts(IEnumerable<Guid> entities)
        {
            IEnumerable<Product> customers = DbContext.Set<Product>().Where(e => entities.Contains(e.ID)).AsEnumerable();
            DbContext.Set<Product>().RemoveRange(customers);
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await DbContext.Set<Product>().AnyAsync(s => s.ID.Equals(id));
        }
    }
}

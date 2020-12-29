using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class ProductTypesRepository : RepositoryBase<ProductType, Guid>
    {
        public ProductTypesRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await DbContext.Set<ProductType>().AnyAsync(p => p.Name.Equals(name));
        }

        public async Task<int> GetMaxOrder()
        {
            return await DbContext.Set<ProductType>().MaxAsync(p => p.Order);
        }
    }
}

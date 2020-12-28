using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class SupplierRepository : RepositoryBase<Supplier, Guid>
    {
        public SupplierRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public void DeleteSuppliers(IEnumerable<Guid> entities)
        {
            IEnumerable<Supplier> suppliers = DbContext.Set<Supplier>().Where(e => entities.Contains(e.ID)).AsEnumerable();
            DbContext.Set<Supplier>().RemoveRange(suppliers);
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await DbContext.Set<Supplier>().AnyAsync(s => s.ID.Equals(id));
        }
    }
}

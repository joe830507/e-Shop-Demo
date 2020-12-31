using e_Shop_Demo.Entities;
using e_Shop_Demo.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class PurchaseRecordRepository : RepositoryBase<PurchaseRecord, Guid>
    {
        public PurchaseRecordRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<IEnumerable<PurchaseRecord>> GetAllRecordsAsync(PurchaseRecordResourceParameters parameters)
        {
            IQueryable<PurchaseRecord> queryableItems = DbContext.Set<PurchaseRecord>()
            .Where(p => p.CustomerID.Equals(parameters.CustomerID))
            .Include(p => p.PurchaseDetailRecords)
            .ThenInclude(p => p.Product).AsQueryable();
            PagedList<PurchaseRecord> pagedList = handlePageInfo(queryableItems, parameters);
            return await Task.FromResult(pagedList);
        }
    }
}

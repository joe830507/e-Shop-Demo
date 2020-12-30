using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_Shop_Demo.Repository
{
    public class PurchaseRecordRepository : RepositoryBase<PurchaseRecord, Guid>
    {
        public PurchaseRecordRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

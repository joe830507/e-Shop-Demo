using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class ImportRecordRepository : RepositoryBase<ImportRecord, Guid>
    {
        public ImportRecordRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

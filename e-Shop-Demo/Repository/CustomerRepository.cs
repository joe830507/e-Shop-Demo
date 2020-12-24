using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class CustomerRepository : RepositoryBase<Customer, Guid>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Customer> GetCustByAccount(string account)
        {
            return await DbContext.Set<Customer>().FirstOrDefaultAsync(e => e.Account.Equals(account));
        }
    }
}

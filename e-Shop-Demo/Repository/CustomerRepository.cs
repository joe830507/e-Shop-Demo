using e_Shop_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void DeleteCustomers(IEnumerable<Guid> entities)
        {
            IEnumerable<Customer> customers = DbContext.Set<Customer>().Where(e => entities.Contains(e.ID)).AsEnumerable();
            DbContext.Set<Customer>().RemoveRange(customers);
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await DbContext.Set<Customer>().AnyAsync(s => s.ID.Equals(id));
        }
    }
}

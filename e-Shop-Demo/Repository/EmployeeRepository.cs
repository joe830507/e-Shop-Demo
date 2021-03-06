﻿using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee, Guid>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Employee> GetEmpByAccount(string account)
        {
            return await DbContext.Set<Employee>().FirstOrDefaultAsync(e => e.Account.Equals(account));
        }

        public void DeleteEmployees(IEnumerable<Guid> entities)
        {
            IEnumerable<Employee> employees = DbContext.Set<Employee>().Where(e => entities.Contains(e.ID)).AsEnumerable();
            DbContext.Set<Employee>().RemoveRange(employees);
        }
    }
}

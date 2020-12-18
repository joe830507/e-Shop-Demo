using e_Shop_Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.IRepository
{
    public interface IRepositoryWrapper
    {
        public EmployeeRepository Employee { get; }
    }
}

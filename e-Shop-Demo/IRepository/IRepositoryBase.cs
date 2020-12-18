using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace e_Shop_Demo.IRepository
{
    public interface IRepositoryBase<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(TId id);
        Task<bool> IsExistAsync(TId id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<bool> SaveAsync();
    }
}

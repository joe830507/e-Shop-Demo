using e_Shop_Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace e_Shop_Demo.IRepository
{
    public interface IRepositoryBase<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync(ResourceParameters parameters);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, ResourceParameters parameters);
        Task<T> GetByIdAsync(TId id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<bool> SaveAsync();
    }
}

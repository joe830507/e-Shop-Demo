using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace e_Shop_Demo.Repository
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T, TId> where T : class
    {
        public DbContext DbContext { get; set; }

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(ResourceParameters parameters)
        {
            if (parameters == null)
                return await Task.FromResult(DbContext.Set<T>().AsEnumerable());
            IQueryable<T> queryableItems = DbContext.Set<T>().AsQueryable();
            PagedList<T> pagedList = handlePageInfo(queryableItems, parameters);
            return await Task.FromResult(pagedList);
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, ResourceParameters parameters)
        {
            if (parameters == null)
                return await Task.FromResult(DbContext.Set<T>().Where(expression).AsEnumerable());
            IQueryable<T> queryableItems = DbContext.Set<T>().Where(expression).AsQueryable();
            PagedList<T> pagedList = handlePageInfo(queryableItems, parameters);
            return await Task.FromResult(pagedList);
        }

        private PagedList<T> handlePageInfo(IQueryable<T> queryableItems, ResourceParameters parameters)
        {
            var totalCount = queryableItems.Count();
            var items = queryableItems.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToList();
            return new PagedList<T>(items, totalCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

    }
}

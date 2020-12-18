﻿using e_Shop_Demo.IRepository;
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
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(DbContext.Set<T>().AsEnumerable());
        }
        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(DbContext.Set<T>().Where(expression).AsEnumerable());
        }
        public async Task<T> GetByIdAsync(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }
        public async Task<bool> IsExistAsync(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id) != null;
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

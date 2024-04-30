using Microsoft.EntityFrameworkCore;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VisitsManagementSystem.BussinessLogic.Logic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
           var result=  await _dbSet.AddAsync(entity);
           return result.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] entities)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                foreach (string entity in entities)
                {
                    query = query.Include(entity);

                }
                return await query.Where(filter).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByGuidAsync(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}

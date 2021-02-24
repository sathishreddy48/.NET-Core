// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using WebApiTask.Repository.IRepository;
    using WebApiTask.Utils;

    /// <summary>
    /// Repository.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">dbContext.</param>
        public Repository(ApplicationDbContext dbContext)
        {
            this.applicationDbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
             await dbSet.AddAsync(entity);
        }

        public async Task<T> GetAsync(int id)
        {
             return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(PagingOptions pagingOptions,
            CancellationToken ct, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return query.FirstOrDefault();
        }

        public async Task RemoveAsync(int id)
        {
            T entity = await dbSet.FindAsync(id);
             await RemoveAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
             dbSet.Remove(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
             dbSet.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }
    }
}

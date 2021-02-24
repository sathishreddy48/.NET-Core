// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApiTask.Utils;

    /// <summary>
    /// IRepository.
    /// </summary>
    /// <typeparam name="T">T. </typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="id">by id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// GetAllAsync.
        /// </summary>
        /// <param name="pagingOptions">pagingOptions.</param>
        /// <param name="ct">ct.</param>
        /// <param name="filter">filter.</param>
        /// <param name="orderBy">orderBy.</param>
        /// <param name="includeProperties">includeProperties.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> GetAllAsync(
            PagingOptions pagingOptions,
            CancellationToken ct,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="orderBy">orderBy.</param>
        /// <param name="includeProperties">includeProperties.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        /// <summary>
        /// GetFirstOrDefaultAsync.
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="includeProperties">includeProperties.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null);

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// RemoveAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task RemoveAsync(int id);

        /// <summary>
        /// RemoveAsync.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task RemoveAsync(T entity);

        /// <summary>
        /// RemoveRangeAsync.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task RemoveRangeAsync(IEnumerable<T> entity);
    }
}

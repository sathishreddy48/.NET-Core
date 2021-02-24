// <copyright file="ITags.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// ITags.
    /// </summary>
    public interface ITags : IRepository<Tags>
    {
        /// <summary>
        /// UpdateTagAsync.
        /// </summary>
        /// <param name="tags">tags</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task UpdateTagAsync(Tags tags);
    }
}

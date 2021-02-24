// <copyright file="IAnswers.cs" company="PlaceholderCompany">
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
    /// IAnswers.
    /// </summary>
    public interface IAnswers : IRepository<Answers>
    {
        /// <summary>
        /// UpdateAnswersAsync.
        /// </summary>
        /// <param name="answers">answers</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task UpdateAnswersAsync(Answers answers);
    }
}

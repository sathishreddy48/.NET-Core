// <copyright file="IQuestions.cs" company="PlaceholderCompany">
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
    /// IQuestions.
    /// </summary>
    public interface IQuestions : IRepository<Questions>
    {
        /// <summary>
        /// UpdateQuestionsAsync.
        /// </summary>
        /// <param name="question">question.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task UpdateQuestionsAsync(Questions question);
    }
}

// <copyright file="IUnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// IUnitOfWork.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ITags Tags { get; }
        IQuestions Questions { get; }
        IAnswers Answers { get; }
        IStoredProcedure StoredProcedure { get; }
        void Save();
    }
}

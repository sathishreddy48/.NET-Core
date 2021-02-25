// <copyright file="UnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository
{
    using Microsoft.Extensions.Configuration;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;

        public IStoredProcedure StoredProcedure { get; private set; }

        public ITags Tags { get; private set; }

        public IQuestions Questions { get; private set; }

        public IAnswers Answers { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext , IConfiguration configuration)
        {
            applicationDbContext = dbContext;
            Questions = new QuestionsRepository(applicationDbContext);
            Tags = new TagsRepository(applicationDbContext);
            Answers = new AnswersRepository(applicationDbContext);
            StoredProcedure = new StoredProcedureExecution(applicationDbContext, configuration);
        }

        public void Dispose()
        {
            this.applicationDbContext.Dispose();
        }

        public void Save()
        {
            applicationDbContext.SaveChanges();
        }
    }
}

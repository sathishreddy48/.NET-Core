// <copyright file="TestBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using WebApiTask.Repository;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// TestBase.
    /// </summary>
    public abstract class TestBase 
    {
        protected ApplicationDbContext GetDbContext()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ApplicationDbContext>()
                                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                  .Options;
            return new ApplicationDbContext(options);
        }
    }

    public class UnitofWork : Repository.IRepository.IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        public IStoredProcedure StoredProcedure { get; private set; }
        public ITags Tags { get; private set; }
        public IQuestions Questions { get; private set; }
        public IAnswers Answers { get; private set; }

        public UnitofWork(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
            Questions = new QuestionsRepository(applicationDbContext);
            Tags = new TagsRepository(applicationDbContext);
            Answers = new AnswersRepository(applicationDbContext);
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }

        public void Save()
        {
            applicationDbContext.SaveChanges();
        }
    }
}

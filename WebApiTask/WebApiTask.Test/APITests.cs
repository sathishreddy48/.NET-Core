// <copyright file="APITests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WebApiTask.Controllers;

    /// <summary>
    /// APITests.
    /// </summary>
    public class APITests : TestBase
    {
        [Xunit.Fact]
        public async System.Threading.Tasks.Task GetAllQuestions()
        {
            using var dbContext = this.GetDbContext();
            using var unity = new UnitofWork(dbContext);
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question1",Tags="c#" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question2" , Tags="asp"});
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question3" ,Tags ="azure"});

            await dbContext.SaveChangesAsync();

            var service = new QuestionsController(unity);
            var result = (IList<Models.Questions>)await service.GetAllAsync();
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(3, result.Count);
        }

        [Xunit.Fact]
        public async System.Threading.Tasks.Task AddQuestionForTopic()
        {
            using var dbContext = this.GetDbContext();
            using var unity = new UnitofWork(dbContext);
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question1", Tags = "c#" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question2", Tags = "asp" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question3", Tags = "azure" });

            await dbContext.SaveChangesAsync();
            Models.Questions newquestion = new Models.Questions() { Question = "question4", Tags = "azure" };
            var service = new QuestionsController(unity);
            var result = await service.AddQuestionsAsync(newquestion);
            Xunit.Assert.NotNull(result);
        }

        [Xunit.Fact]
        public async System.Threading.Tasks.Task GetQuestionsByTag()
        {
            using var dbContext = this.GetDbContext();
            using var unity = new UnitofWork(dbContext);
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question1", Tags = "c#" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question2", Tags = "asp" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question3", Tags = "azure" });

            await dbContext.SaveChangesAsync();

            var service = new QuestionsController(unity);
            var result = (IList<Models.Questions>)await service.GetQuestionsByTags("c#");
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal("question1", result[0].Question);
        }

        [Xunit.Fact]
        public async System.Threading.Tasks.Task GetAnswersForQuestion()
        {
            using var dbContext = this.GetDbContext();
            using var unity = new UnitofWork(dbContext);
            var guid = Guid.NewGuid();
            dbContext.Questions.Add(new Models.Questions { Id = guid, Question = "question1", Tags = "c#" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question2", Tags = "asp" });
            dbContext.Questions.Add(new Models.Questions { Id = Guid.NewGuid(), Question = "question3", Tags = "azure" });
            await dbContext.SaveChangesAsync();
            dbContext.Answers.Add(new Models.Answers { Id = Guid.NewGuid(), Answer = "answer1", QuestionID = guid });
            dbContext.Answers.Add(new Models.Answers { Id = Guid.NewGuid(), Answer = "answer2", QuestionID = guid });
            dbContext.Answers.Add(new Models.Answers { Id = Guid.NewGuid(), Answer = "answer3", QuestionID = guid });

            await dbContext.SaveChangesAsync();

            var service = new AnswersController(unity);
            var result = (IList<Models.Answers>)await service.GetAnswersByquestionAsync("question1");
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(3, result.Count);
        }
    }
}

// <copyright file="QuestionsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// QuestionsRepository.
    /// </summary>
    public class QuestionsRepository : Repository<Questions>, IQuestions
    {
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionsRepository"/> class.
        /// </summary>
        /// <param name="dbContext">dbContext.</param>
        public QuestionsRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.applicationDbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task UpdateQuestionsAsync(Questions question)
        {
            var questionsEntity = this.applicationDbContext.Questions.FirstOrDefault(t => t.Id == question.Id);

            if (questionsEntity != null)
            {
                questionsEntity.Tags = question.Tags;
                questionsEntity.Question = question.Question;
                await this.applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

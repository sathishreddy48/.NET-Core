// <copyright file="AnswersRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Repository
{
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiTask.Models;
    using WebApiTask.Repository.IRepository;

    /// <summary>
    /// AnswersRepository.
    /// </summary>
    public class AnswersRepository : Repository<Answers>, IAnswers
    {
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswersRepository"/> class.
        /// </summary>
        /// <param name="dbContext">dbContext.</param>
        public AnswersRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.applicationDbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task UpdateAnswersAsync(Answers answer)
        {
            var answerEntity = this.applicationDbContext.Answers.FirstOrDefault(t => t.Id == answer.Id);

            if (answerEntity != null)
            {
                answerEntity.Answer = answer.Answer;
                await this.applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

using WebApiTask.Models;
using WebApiTask.Repository.IRepository;
using System.Linq;

namespace WebApiTask.Repository
{
    public class AnswersRepository : Repository<Answers>, IAnswers
    {
        private readonly ApplicationDbContext applicationDbContext;
        public AnswersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }

        public void UpdateAnswerAsync(Answers answer)
        {
            var answerEntity = applicationDbContext.Answers.FirstOrDefault(t => t.Id == answer.Id);

            if (answerEntity != null)
            {
                answerEntity.Answer = answer.Answer;
                applicationDbContext.SaveChanges();
            }
        }
    }
}

using WebApiTask.Models;
using WebApiTask.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Repository
{
    public class QuestionsRepository : Repository<Questions>, IQuestions
    {
        private readonly ApplicationDbContext applicationDbContext;
        public QuestionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }

        public async Task UpdateQuestionsAsync(Questions question)
        {
            var questionsEntity = applicationDbContext.Questions.FirstOrDefault(t => t.Id == question.Id);

            if (questionsEntity != null)
            {
                questionsEntity.Tags = question.Tags;
                questionsEntity.Question = question.Question;
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

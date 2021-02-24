using WebApiTask.Models;
using WebApiTask.Repository.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Repository
{
    public class AnswersRepository : Repository<Answers>, IAnswers
    {
        private readonly ApplicationDbContext applicationDbContext;
        public AnswersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }

        public async Task UpdateAnswersAsync(Answers answer)
        {
            var answerEntity = applicationDbContext.Answers.FirstOrDefault(t => t.Id == answer.Id);

            if (answerEntity != null)
            {
                answerEntity.Answer = answer.Answer;
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

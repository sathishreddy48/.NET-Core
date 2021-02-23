using WebApiTask.Models;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Repository
{
    public class AnswersRepository : Repository<Answers>, IAnswers
    {
        private readonly ApplicationDbContext applicationDbContext;
        public AnswersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }
    }
}

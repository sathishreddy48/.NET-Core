using WebApiTask.Models;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Repository
{
    public class QuestionsRepository : Repository<Questions>, IQuestions
    {
        private readonly ApplicationDbContext applicationDbContext;
        public QuestionsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }
    }
}

using WebApiTask.Models;
using WebApiTask.Repository.IRepository;

namespace WebApiTask.Repository
{
    public class TagsRepository : Repository<Tags>, ITags
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TagsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }
    }
}

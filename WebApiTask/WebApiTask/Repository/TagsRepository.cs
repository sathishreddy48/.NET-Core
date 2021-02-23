using WebApiTask.Models;
using WebApiTask.Repository.IRepository;
using System.Linq;

namespace WebApiTask.Repository
{
    public class TagsRepository : Repository<Tags>, ITags
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TagsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            applicationDbContext = dbContext;
        }

        public void UpdateTagAsync(Tags tags)
        {
            var tagsEntity = applicationDbContext.Tags.FirstOrDefault(t => t.Id == tags.Id);

            if (tagsEntity != null)
            {
                tagsEntity.Tag = tags.Tag;
                applicationDbContext.SaveChanges();
            }
        }
    }
}

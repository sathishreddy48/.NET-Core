namespace WebApiTask
{
    using Microsoft.EntityFrameworkCore;
    using WebApiTask.Models;
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// initializes new context of the <see cref="ApplicationDbContext"/>
        /// </summary>
        /// <param name="contextOptions"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {

        }

        /// <summary>
        /// Get or sets tagsDBEntity
        /// </summary>
        public DbSet<TagsDBEntity> TagsDBEntity { get; set; }

        /// <summary>
        /// Get or Sets QuestionsDBEntity
        /// </summary>
        public DbSet<QuestionsDBEntity> QuestionsDBEntity { get; set; }

        /// <summary>
        /// Get or Sets AnswersDBEntity
        /// </summary>
        public DbSet<AnswersDBEntity> AnswersDBEntity { get; set; }
    }
}
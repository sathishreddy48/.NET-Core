// <copyright file="ApplicationDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask
{
    using Microsoft.EntityFrameworkCore;
    using WebApiTask.Models;

    /// <summary>
    /// ApplicationDbContext.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="contextOptions">contextOptions</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        /// <summary>
        /// Gets or sets get or sets Tags.
        /// </summary>
        public DbSet<Tags> Tags { get; set; }

        /// <summary>
        /// Gets or sets get or Sets Questions.
        /// </summary>
        public DbSet<Questions> Questions { get; set; }

        /// <summary>
        /// Gets or sets get or Sets Answers.
        /// </summary>
        public DbSet<Answers> Answers { get; set; }
    }
}
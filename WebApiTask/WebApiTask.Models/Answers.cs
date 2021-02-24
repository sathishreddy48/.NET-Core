// <copyright file="Answers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    [Table("Answers")]
    public class Answers
    {
        /// <summary>
        /// Gets or sets a ID of Answers entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Answer of Answers Entity.
        /// </summary>
        [Column("Answer")]
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets QuestionID of Answers Entity.
        /// </summary>
        [Column("QuestionID")]
        public Guid QuestionID { get; set; }
    }
}

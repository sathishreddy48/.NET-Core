using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Models
{
    //[Table("Answers")]
    public class AnswersDBEntity
    {
        /// <summary>
        /// Gets or sets a ID of Answers entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Answer of Answers Entity
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets QuestionID of Answers Entity
        /// </summary>
        public Guid QuestionID { get; set; }
    }
}

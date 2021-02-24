using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Models
{

    [Table("Questions")]
    public class Questions
    {
        /// <summary>
        /// Gets or sets a ID of QuestionsDB entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Question of QuestionsDB Entity
        /// </summary>
        [Column("Question")]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets Tags of QuestionsDB Entity
        /// </summary>
        [Column("Tags")]
        public string Tags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("Tags")]
    public class TagsDBEntity
    {
        /// <summary>
        /// Gets or sets a ID of the Tags entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Tags of TagsDB Entity
        /// </summary>
        public string Tags { get; set; }

    }
}

// <copyright file="Tags.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Tags
    /// </summary>
    [Table("Tags")]
    public class Tags
    {
        /// <summary>
        /// Gets or sets a ID of the Tags entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Tags of TagsDB Entity.
        /// </summary>
        [Column("Tag")]
        public string Tag { get; set; }

    }
}

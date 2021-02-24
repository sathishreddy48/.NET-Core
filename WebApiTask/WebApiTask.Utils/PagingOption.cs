// <copyright file="PagingOption.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Utils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// PagingOptions.
    /// </summary>
    public sealed class PagingOptions
    {
        public const int MaxPageSize = 100;

        [FromQuery]
        [Range(1, int.MaxValue, ErrorMessage = "Offset must be greater than 0.")]
        public int? Offset { get; set; }

        [FromQuery]
        [Range(1, MaxPageSize, ErrorMessage = "Limit must be greater than 0 and less than 100.")]
        public int? Limit { get; set; }
    }
}

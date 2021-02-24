// <copyright file="StringUtils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApiTask.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// StringUtils.
    /// </summary>
    public static class StringUtils
    {
      public static string[] SplitString(string inputString)
      {
            char[] whitespace = new char[] { ' ', '\t' };
            return inputString.Split(whitespace);
      }

    }
}

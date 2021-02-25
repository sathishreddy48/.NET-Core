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
            return inputString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static double Compare(string a, string b)
        {
            var aWords = a.Split(' ');
            var bWords = b.Split(' ');
            List<string> aList = new List<string>(aWords);
            List<string> blist = new List<string>(bWords);
            // double matches = (double)aWords.fi.fi(x => bWords.Contains(x));
            //return matches / (double)aList.Count;
            return 100.00d;
        }
    }
}

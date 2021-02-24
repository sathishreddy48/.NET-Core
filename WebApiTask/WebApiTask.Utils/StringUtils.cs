using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTask.Utils
{
    public static class StringUtils
    {
      public static string[] SplitString(string inputString)
      {
            char[] whitespace = new char[] { ' ', '\t' };
            return inputString.Split(whitespace);
      }

    }
}

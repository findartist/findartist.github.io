using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2Minds.Utilities
{
    public static class Extensions
    {
        public static int RoundOff(this int i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-abcdefghijklmnopqrstuvwxyz. 0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText.Resources
{
    public static class ResourcesEN
    {
        public const string NEGATIVE = "minus";          

        public static readonly Dictionary<long, string> FIRST_100 = new Dictionary<long, string>()
        {
            { 0, "ноль" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
        };

        public static readonly Dictionary<long, string> HUNDREDS = new Dictionary<long, string>()
        {
            { 0, "handred" },
        };

        public static readonly Dictionary<long, string> MULTIPLES_OF_1000 = new Dictionary<long, string>()
        {
            { 0, "" },
            { 1, "thousand" },
            { 2, "million" },
            { 3, "billion" },
            { 4, "trillion" },
            { 5, "quadrillion" },
        };
    }
}

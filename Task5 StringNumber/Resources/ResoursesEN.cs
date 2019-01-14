using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model
{
    public static class ResourcesEN
    {
        public static readonly int maxRank = 5;
        public static readonly string negative = "minus";      

        public static readonly Dictionary<int, string> first100 = new Dictionary<int, string>()
        {
            { 0, "ноль" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "четыре" },
            { 5, "пять" },
            { 6, "шесть" },
            { 7, "семь" },
            { 8, "восемь" },
            { 9, "девять" },
            { 10, "десять" },
            { 11, "одиннадцать" },
            { 12, "двенадцать" },
            { 13, "тринадцать" },
            { 14, "четырадцать" },
            { 15, "пятнадцать" },
            { 16, "шестнадцать" },
            { 17, "семнадцать" },
            { 18, "восемнадцать" },
            { 19, "девятнадцать" },
            { 20, "двадцать" },
            { 30, "тридцать" },
            { 40, "сорок" },
            { 50, "пятьдесят" },
            { 60, "шестьдесят" },
            { 70, "семьдесят" },
            { 80, "восемьдесят" },
            { 90, "девяносто" },
            { 100, "handred" }
        };

        public static readonly Dictionary<int, string> multiplesOf1000 = new Dictionary<int, string>()
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

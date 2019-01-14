using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model
{
    public static class ResourcesRU
    {
        public static readonly int maxRank = 5;
        public static readonly string negative = "минус";
      
        public static readonly Dictionary<int, string> first100 = new Dictionary<int, string>()
        {
            { 0, "ноль" },
            { 1, "один" },
            { 2, "два" },
            { 3, "три" },
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
            { 100, "сто" }
        };

        public static readonly Dictionary<int, string> first100FemaleChanges = new Dictionary<int, string>()
        {
            { 1, "одна" },
            { 2, "две" }
        };

        public static readonly Dictionary<int, string> hundreds = new Dictionary<int, string>()
        {
            { 1, "сто" },
            { 2, "двести" },
            { 3, "триста" },
            { 4, "четыреста" },
            { 5, "пятьсот" },
            { 6, "шестьсот" },
            { 7, "семьсот" },
            { 8, "восемьсот" },
            { 9, "девятьсот" }
        };

        public static readonly Dictionary<int, string> multiplesOf1000 = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "тысяча" },
            { 2, "миллион" },
            { 3, "миллиард" },
            { 4, "триллион" },
            { 5, "квадриллион" },
        };

        public static readonly Dictionary<int, string> multiplesOf1000Form234 = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "тысячи" },
            { 2, "миллиона" },
            { 3, "миллиарда" },
            { 4, "триллиона" },
            { 5, "квадриллиона" },
        };

        public static readonly Dictionary<int, string> multiplesOf1000Form5 = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "тысяч" },
            { 2, "миллионов" },
            { 3, "миллиардов" },
            { 4, "триллионов" },
            { 5, "квадриллионов" },
        };
    }
}

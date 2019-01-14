using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Resources
{
    public static class ResourcesUA
    {
        public static readonly int maxRank = 5;
        public static readonly string negative = "мінус";

        public static readonly Dictionary<long, string> first100 = new Dictionary<long, string>()
        {
            { 0, "нуль" },
            { 1, "один" },
            { 2, "два" },
            { 3, "три" },
            { 4, "чотири" },
            { 5, "п'ять" },
            { 6, "шість" },
            { 7, "сім" },
            { 8, "вісім" },
            { 9, "дев'ять" },
            { 10, "десять" },
            { 11, "одинадцять" },
            { 12, "дванадцять" },
            { 13, "тринадцять" },
            { 14, "чотирнадцять" },
            { 15, "п'ятнадцять" },
            { 16, "шістнадцять" },
            { 17, "сімнадцять" },
            { 18, "вісімнадцять" },
            { 19, "дев'ятнадцять" },
            { 20, "двадцять" },
            { 30, "тридцять" },
            { 40, "сорок" },
            { 50, "п'ятдесят" },
            { 60, "шістдесят" },
            { 70, "сімдесят" },
            { 80, "вісімдесят" },
            { 90, "дев'яносто" },
            { 100, "сто" }
        };

        public static readonly Dictionary<long, string> first100FemaleChanges = new Dictionary<long, string>()
        {
            { 1, "одна" },
            { 2, "дві" }
        };

        public static readonly Dictionary<long, string> hundreds = new Dictionary<long, string>()
        {
            { 1, "сто" },
            { 2, "двісти" },
            { 3, "триста" },
            { 4, "чотириста" },
            { 5, "п'ятсот" },
            { 6, "шістсот" },
            { 7, "сімсот" },
            { 8, "вісімсот" },
            { 9, "дев'ятсот" }
        };

        public static readonly Dictionary<long, string> multiplesOf1000 = new Dictionary<long, string>()
        {
            { 0, "" },
            { 1, "тисяча" },
            { 2, "мільйон" },
            { 3, "мілльярд" },
            { 4, "трильйон" },
            { 5, "квадрильйон" },
        };

        public static readonly Dictionary<long, string> multiplesOf1000Form234 = new Dictionary<long, string>()
        {
            { 0, "" },
            { 1, "тисячі" },
            { 2, "мільйони" },
            { 3, "мілльярди" },
            { 4, "трильйони" },
            { 5, "квадрильйоин" },
        };

        public static readonly Dictionary<long, string> multiplesOf1000Form5 = new Dictionary<long, string>()
        {
            { 0, "" },
            { 1, "тисяч" },
            { 2, "мільйонів" },
            { 3, "мілльярдів" },
            { 4, "трильйонів" },
            { 5, "квадрильйонів" },
        };    
    }
}

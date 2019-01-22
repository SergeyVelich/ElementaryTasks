using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LuckyTickets.Resources;

namespace LuckyTickets.Model
{
    public class LuckyTicketsGeneratorPiter : LuckyTicketsGenerator
    {
        public LuckyTicketsGeneratorPiter(byte quantityDigits) : base(quantityDigits)
        {

        }

        protected override bool[] GetPattern()
        {
            bool[] pattern = new bool[QuantityDigits];

            for (int i = 0; i < QuantityDigits; i++)
            {
                pattern[i] = i % 2 == 0;
            }

            return pattern;
        }
    }
}

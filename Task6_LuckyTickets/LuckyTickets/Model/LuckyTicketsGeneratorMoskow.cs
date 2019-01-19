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
    public class LuckyTicketsGeneratorMoskow : LuckyTicketsGenerator
    {
        public LuckyTicketsGeneratorMoskow(byte quantityDigits) : base(quantityDigits)
        {

        }

        protected override bool[] GetPattern()
        {
            bool[] pattern = new bool[QuantityDigits];

            for (int i = 0; i < QuantityDigits; i++)
            {
                pattern[i] = i < QuantityDigits / 2;
            }

            return pattern;
        }
    }
}

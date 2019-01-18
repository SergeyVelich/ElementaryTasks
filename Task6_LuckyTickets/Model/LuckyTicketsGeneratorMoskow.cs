using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task6_LuckyTickets.Resources;

namespace Task6_LuckyTickets.Model
{
    class LuckyTicketsGeneratorMoskow : LuckyTicketsGenerator
    {
        public LuckyTicketsGeneratorMoskow(int quantityDigits) : base(quantityDigits)
        {

        }

        protected override int[] GetPattern()
        {
            int[] pattern = new int[QuantityDigits / 2];

            for (int i = 0; i < QuantityDigits; i++)
            {
                if (i < pattern.Length)
                {
                    pattern[i] = i;
                }
            }

            return pattern;
        }
    }
}

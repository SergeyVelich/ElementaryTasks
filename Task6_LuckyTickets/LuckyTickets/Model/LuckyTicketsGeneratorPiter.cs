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
    class LuckyTicketsGeneratorPiter : LuckyTicketsGenerator
    {
        public LuckyTicketsGeneratorPiter(int quantityDigits) : base(quantityDigits)
        {

        }

        protected override int[] GetPattern()
        {
            int[] pattern = new int[QuantityDigits / 2];

            for (int i = 0; i < QuantityDigits; i++)
            {
                if (i % 2 != 0)
                {
                    pattern[i / 2] = i;
                }
            }

            return pattern;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.Model
{
    public class Ticket
    {
        public int QuantityDigits { get; private set; }
        public int Number { get; private set; }
        public int[] NumbersAsDigit { get; private set; }

        public Ticket(int number, int quantityDigits)
        {
            Number = number;
            QuantityDigits = quantityDigits;

            NumbersAsDigit = GetNumbersAsRanks();
        }

        private int[] GetNumbersAsRanks()
        {
            int number = Number;
            int[] numbersAsDigit = new int[QuantityDigits];
            for (int i = QuantityDigits - 1; i >= 0; i--)
            {
                numbersAsDigit[i] = number % 10;
                number /= 10;
            }

            return numbersAsDigit;
        }

        public override string ToString()
        { 
            return Number.ToString().PadLeft(QuantityDigits, '0');
        }

        public int this[int index]
        {
            get
            {
                return this.NumbersAsDigit[index];
            }
        }
    }
}

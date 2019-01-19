using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.Model
{
    public class Ticket
    {
        public int QuantityDigits { get; private set; }
        public uint Number { get; private set; }
        public byte[] NumbersAsDigit { get; private set; }

        public Ticket(uint number, byte quantityDigits)
        {
            Number = number;
            QuantityDigits = quantityDigits;

            NumbersAsDigit = GetNumbersAsRanks();
        }

        private byte[] GetNumbersAsRanks()
        {
            uint number = Number;
            byte[] numbersAsDigit = new byte[QuantityDigits];
            for (int i = QuantityDigits - 1; i >= 0; i--)
            {
                numbersAsDigit[i] = (byte)(number % 10);
                number /= 10;
            }

            return numbersAsDigit;
        }

        public override string ToString()
        { 
            return Number.ToString().PadLeft(QuantityDigits, '0');
        }

        public byte this[int index]
        {
            get
            {
                return this.NumbersAsDigit[index];
            }
        }
    }
}

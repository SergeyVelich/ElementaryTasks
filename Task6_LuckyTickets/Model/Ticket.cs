using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.Model
{
    public class Ticket
    {
        private int _quantityDigits;
        private int _number;
        private int[] _numbersAsDigit;

        public Ticket(int number, int quantityDigits)
        {
            _number = number;
            _quantityDigits = quantityDigits;

            FillNumbersAsRanks();
        }

        private void FillNumbersAsRanks()
        {
            int tempNumber;
            _numbersAsDigit = new int[_quantityDigits];
            for (int i = 0; i < _quantityDigits - 1; i++)
            {
                _numbersAsDigit[i] = _number % 10;
                _number /= 10;
            }

            _numbersAsDigit.Reverse();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (int number in _numbersAsDigit)
            {
                result.Append(number.ToString());
            }
            return result.ToString();
        }

        public int this[int index]
        {
            get
            {
                return this._numbersAsDigit[index];
            }
        }
    }
}

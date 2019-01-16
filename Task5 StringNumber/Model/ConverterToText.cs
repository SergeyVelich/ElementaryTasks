using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model
{
    public abstract class ConverterToText
    {
        public const int MAX_RANK = 5;

        protected Dictionary<long, string> _first100;
        protected Dictionary<long, string> _first100FemaleChanges;
        protected Dictionary<long, string> _hundreds;
        protected Dictionary<long, string> _multiplesOf1000;
        protected Dictionary<long, string> _multiplesOf1000Form234;
        protected Dictionary<long, string> _multiplesOf1000Form5;
        protected string _negative;

        protected abstract void LoadResources();

        public virtual string Convert(long value)
        {
            StringBuilder result = new StringBuilder();
            bool minus = false;

            if (value == 0)
            {
                result.Insert(0, _first100[value]);
            }
            else
            {
                if (value < 0)
                {
                    value = Math.Abs(value);
                    minus = true;
                }

                for (int i = 0; i <= MAX_RANK && value > 0; i++)
                {
                    result.Insert(0, ConvertWithRank(value, i));
                    value /= 1000;
                }

                if (minus)
                {
                    result.Insert(0, " ");
                    result.Insert(0, _negative);
                }
            }

            result[0] = char.ToUpper(result[0]);

            return result.ToString();
        }

        protected virtual string ConvertWithRank(long value, int rank)
        {
            StringBuilder result = new StringBuilder();

            if (value == 0)
            {
                result.Append(String.Empty);
            }

            short rem1000 = (short)(value % 1000);


            if (rem1000 == 0)
            {
                result.Append(_first100[rem1000]);
            }
            else
            {
                result.Append(ConvertHundreds(rem1000, rank));

                if (rank > 0)
                {
                    result.AppendFormat(" {0}", GetFormMultiplesOf1000(rem1000, rank));
                }

                if (result.Length != 0) result.Append(" ");
            }

            return result.ToString();
        }

        protected abstract string ConvertHundreds(short value, int rank);
        protected abstract string GetFormMultiplesOf1000(short val, int rank);
    }
}

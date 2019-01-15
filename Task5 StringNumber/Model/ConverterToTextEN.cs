using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_StringNumber.Resources;

namespace Task5_StringNumber.Model
{
    public class ConverterToTextEN: ConverterToText
    {
        public ConverterToTextEN()
        {
            LoadResources();
        }

        protected override void LoadResources()
        {
            _first100 = ResourcesEN.first100;
            _multiplesOf1000 = ResourcesEN.multiplesOf1000;
            _negative = ResourcesEN.negative;
            _maxRank = ResourcesEN.maxRank;
        }

        public override string Convert(long value)
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

                for (int i = 0; i <= _maxRank && value > 0; i++)
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

        public string ConvertWithRank(long value, int rank)
        {
            StringBuilder result = new StringBuilder();

            if (value == 0)
            {
                result.Append(String.Empty);
            }

            long rem1000 = value % 1000;

            if (rem1000 == 0)
            {
                result.Append(_first100[rem1000]);
            }
            else
            {
                result.AppendFormat("{0} ", _hundreds[rem1000 / 100]);

                long rem100 = rem1000 % 100;
                if (rem100 < 20)
                {
                    result.AppendFormat("{0}", _first100[rem100]);                 
                }
                else
                {
                    result.AppendFormat("{0} ", _first100[rem100 / 10 * 10]);
                    result.AppendFormat("{0}", _first100[rem100 % 10]);
                }

                if(rank > 0)
                {
                    result.AppendFormat(" {0}", GetFormMultiplesOf1000(rem1000, rank));
                }               

                if (result.Length != 0) result.Append(" ");
            } 
            
            return result.ToString();
        }

        public string GetFormMultiplesOf1000(long val, int rank)
        {
            return _multiplesOf1000[rank];
        }
    }
}

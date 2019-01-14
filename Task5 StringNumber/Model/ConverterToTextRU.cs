using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_StringNumber.Model
{
    public class ConverterToTextUA: ConverterToText
    {
        public ConverterToTextUA()
        {
            LoadResources();
        }

        protected override void LoadResources()
        {
            _first100 = ResourcesRU.first100;
            _first100FemaleChanges = ResourcesRU.first100FemaleChanges;
            _hundreds = ResourcesRU.hundreds;
            _multiplesOf1000 = ResourcesRU.multiplesOf1000;
            _multiplesOf1000Form234 = ResourcesRU.multiplesOf1000Form234;
            _multiplesOf1000Form5 = ResourcesRU.multiplesOf1000Form5;
            _negative = ResourcesRU.negative;
            _maxRank = ResourcesRU.maxRank;
        }

        public override string Convert(int value)
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

            //Делаем первую букву заглавной
            result[0] = char.ToUpper(result[0]);

            return result.ToString();
        }

        public string ConvertWithRank(int value, int rank)
        {
            StringBuilder result = new StringBuilder();

            if (value == 0)
            {
                result.Append("");
            }

            int rem1000 = value % 1000;

            if (rem1000 == 0)
            {
                result.Append(_first100[rem1000]);
            }
            else
            {
                result.AppendFormat("{0} ", _hundreds[rem1000 / 100]);

                int rem100 = rem1000 % 100;
                if (rem100 < 20)
                {
                    if (rem100 == 1 || rem100 == 2 && rank == 1)
                    {
                        result.AppendFormat("{0}", _first100FemaleChanges[rem100]);
                    }
                    else
                    {
                        result.AppendFormat("{0}", _first100[rem100]);
                    }                   
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

        public string GetFormMultiplesOf1000(int val, int rank)
        {
            int t = (val % 100 > 20) ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return _multiplesOf1000[rank];
                case 2: case 3: case 4: return _multiplesOf1000Form234[rank];
                default: return _multiplesOf1000Form5[rank];
            }
        }
    }
}

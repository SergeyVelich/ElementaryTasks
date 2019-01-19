using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Resources;

namespace NumberToText.Model
{
    class ConverterToTextUA: ConverterToText
    {
        public ConverterToTextUA()
        {
            LoadResources();
        }

        protected override void LoadResources()
        {
            _first100 = ResourcesUA.FIRST_100;
            _first100FemaleChanges = ResourcesUA.FIRST_100_FEMALE_CHANGES;
            _hundreds = ResourcesUA.HUNDREDS;
            _multiplesOf1000 = ResourcesUA.MULTIPLES_OF_1000;
            _multiplesOf1000Form234 = ResourcesUA.MULTIPLES_OF_1000_FORM234;
            _multiplesOf1000Form5 = ResourcesUA.MULTIPLES_OF_1000_FORM5;
            _negative = ResourcesUA.NEGATIVE;
        }      

        protected override string ConvertHundreds(short value, int rank)
        {
            StringBuilder result = new StringBuilder();

            result.Append(_hundreds[value / 100].ToString());
            result.Append(" ");

            short rem100 = (short)(value % 100);
            if (rem100 < 20)
            {
                if (rem100 == 1 || rem100 == 2 && rank == 1)
                {
                    result.Append(_first100FemaleChanges[rem100].ToString());
                }
                else
                {
                    result.Append(_first100[rem100].ToString());
                }
            }
            else
            {
                result.Append(_first100[rem100 / 10 * 10].ToString());
                result.Append(" ");
                result.Append(_first100[rem100 % 10].ToString());
            }

            return result.ToString();
        }

        protected override string GetFormMultiplesOf1000(short value, int rank)
        {
            long t;
            if (value % 100 < 20)
            {
                t = value % 20;
            }
            else
            {
                t = value % 10;
            }

            string formMultiplesOf1000;
            switch (t)
            {
                case 1:
                    formMultiplesOf1000 =  _multiplesOf1000[rank];
                    break;
                case 2: case 3: case 4:
                    formMultiplesOf1000 =  _multiplesOf1000Form234[rank];
                    break;
                default:
                    formMultiplesOf1000 =  _multiplesOf1000Form5[rank];
                    break;
            }

            return formMultiplesOf1000;
        }
    }
}

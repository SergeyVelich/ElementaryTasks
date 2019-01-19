using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Resources;

namespace NumberToText.Model
{
    class ConverterToTextEN: ConverterToText
    {
        public ConverterToTextEN()
        {
            LoadResources();
        }

        protected override void LoadResources()
        {
            _first100 = ResourcesEN.FIRST_100;
            _multiplesOf1000 = ResourcesEN.MULTIPLES_OF_1000;
            _hundreds = ResourcesEN.HUNDREDS;
            _negative = ResourcesEN.NEGATIVE;
        }

        protected override string ConvertHundreds(short value, int rank)
        {
            StringBuilder result = new StringBuilder();

            result.Append(_first100[value / 100].ToString());
            result.Append(" ");
            result.Append(_hundreds[0].ToString());
            result.Append(" ");

            int rem100 = value % 100;
            if (rem100 < 20)
            {
                result.Append(_first100[rem100]);
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
            return _multiplesOf1000[rank];
        }
    }
}

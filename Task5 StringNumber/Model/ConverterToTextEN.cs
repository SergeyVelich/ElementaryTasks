using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_StringNumber.Resources;

namespace Task5_StringNumber.Model
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

            result.AppendFormat("{0} ", _first100[value / 100]);
            result.AppendFormat("{0} ", _hundreds[0]);

            int rem100 = value % 100;
            if (rem100 < 20)
            {
                result.AppendFormat("{0}", _first100[rem100]);
            }
            else
            {
                result.AppendFormat("{0} ", _first100[rem100 / 10 * 10]);
                result.AppendFormat("{0}", _first100[rem100 % 10]);
            }

            return result.ToString();
        }

        protected override string GetFormMultiplesOf1000(short value, int rank)
        {
            return _multiplesOf1000[rank];
        }
    }
}

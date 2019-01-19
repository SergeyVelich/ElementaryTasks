using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Resources;

namespace NumberToText.Model
{
    class ConverterToTextRU : ConverterToTextUA
    {
        public ConverterToTextRU()
        {
            LoadResources();
        }

        protected override void LoadResources()
        {
            _first100 = ResourcesRU.FIRST_100;
            _first100FemaleChanges = ResourcesRU.FIRST_100_FEMALE_CHANGES;
            _hundreds = ResourcesRU.HUNDREDS;
            _multiplesOf1000 = ResourcesRU.MULTIPLES_OF_1000;
            _multiplesOf1000Form234 = ResourcesRU.MULTIPLES_OF_1000_FORM234;
            _multiplesOf1000Form5 = ResourcesRU.MULTIPLES_OF_1000_FORM5;
            _negative = ResourcesRU.NEGATIVE;
        }
    }
}

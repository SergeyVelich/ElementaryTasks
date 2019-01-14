using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model
{
    public class PowSequence : Sequence
    {
        public PowSequence(int upLimit) : base(upLimit)
        {
            FillSequence();
        }

        protected override void FillSequence()
        {
            int upLimitNumber = (int)Math.Sqrt(_upLimit);
            int lowLimitNumber = (int)Math.Sqrt(_lowLimit);
            for (int i = lowLimitNumber; i <= upLimitNumber; i++)
            {
                _sequenceMembers.Add(i);
            }
        }
    }
}

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

        }

        override public void FillSequence()
        {
            int upLimitNumber = (int)Math.Sqrt(_upLimit);
            for (int i = 1; i <= upLimitNumber; i++)
            {
                _sequenceMembers.Add(i);
            }
        }
    }
}

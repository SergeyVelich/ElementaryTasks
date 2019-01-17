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

        protected override void GenerateSequence()
        {
            int upLimitNumber = (int)Math.Sqrt(UpLimit);
            int lowLimitNumber = (int)Math.Sqrt(LowLimit);
            for (int i = lowLimitNumber; i <= upLimitNumber; i++)
            {
                SequenceMembers.Add(i);
            }
        }
    }
}

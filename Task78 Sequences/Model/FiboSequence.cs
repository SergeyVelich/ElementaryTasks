using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model
{
    class FiboSequence : Sequence
    {
        public FiboSequence(int lowLimit, int upLimit) : base(lowLimit, upLimit)
        {
            
        }

        protected override void GenerateSequence()
        {
            int p;
            int p1 = 0;
            int p2 = 1;

            for (int i = 0; p2 < UpLimit; i++)
            {
                if (p2 > LowLimit)
                {
                    SequenceMembers.Add(p2);
                }
                p = p1;
                p1 = p2;
                p2 = p2 + p;
            }
        }
    }
}

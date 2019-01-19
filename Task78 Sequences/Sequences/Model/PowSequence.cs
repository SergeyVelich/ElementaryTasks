using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model
{
    public class PowSequence : ISequence
    {
        public long LowLimit { get; private set; }
        public long UpLimit { get; private set; }

        public PowSequence(long upLimit)
        {
            LowLimit = 0;
            UpLimit = upLimit;
        }

        public IEnumerable<long> GetSequence()
        {
            long upLimitNumber = (long)Math.Sqrt(UpLimit);
            long lowLimitNumber = (int)Math.Sqrt(LowLimit);
            for (long i = lowLimitNumber; i <= upLimitNumber; i++)
            {
                yield return i;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model
{
    public class FiboSequence : ISequence
    {
        public long LowLimit { get; private set; }
        public long UpLimit { get; private set; }

        public FiboSequence(long lowLimit, long upLimit)
        {
            LowLimit = lowLimit;
            UpLimit = upLimit;
        }

        public IEnumerable<long> GetSequence()
        {
            long p1 = 0;
            long p2 = 1;
            while (p1 + p2 <= UpLimit)
            {
                long p = p1 + p2;
                p1 = p2;
                p2 = p;
                if (p2 > LowLimit)
                {
                    yield return p2;
                }
            }
        }
    }
}

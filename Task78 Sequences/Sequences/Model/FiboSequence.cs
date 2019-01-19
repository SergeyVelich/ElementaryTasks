using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model
{
    class FiboSequence : ISequence
    {
        public int LowLimit { get; set; }
        public int UpLimit { get; set; }

        public FiboSequence(int lowLimit, int upLimit)
        {
            LowLimit = lowLimit;
            UpLimit = upLimit;
        }

        public IEnumerator GetEnumerator()
        {
            int p;
            int p1 = 0;
            int p2 = 1;
            while (p1 + p2 <= UpLimit)
            {
                p = p1 + p2;
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

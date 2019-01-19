using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model
{
    public class PowSequence : ISequence
    {
        public int LowLimit { get; set; }
        public int UpLimit { get; set; }

        public PowSequence(int upLimit)
        {
            LowLimit = 0;
            UpLimit = upLimit;
        }

        public IEnumerator GetEnumerator()
        {
            int upLimitNumber = (int)Math.Sqrt(UpLimit);
            int lowLimitNumber = (int)Math.Sqrt(LowLimit);
            for (int i = lowLimitNumber; i <= upLimitNumber; i++)
            {
                yield return i;
            }
        }
    }
}

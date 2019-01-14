using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_EnvelopesAnalysis.Model
{
    public class EnvelopeComparer
    {
        private Envelope[] _envelopes;

        public EnvelopeComparer(Envelope[] envelopes)
        {
            _envelopes = envelopes;
        }

        public int Compare(Envelope envOut, Envelope envIn, out string result)
        {
            int comparisonResult = envOut.CompareTo(envIn);
            if (comparisonResult > 0)
            {
                result = "The second envelope can be inserted in the first";
            }
            else
            {
                result = "The second envelope can't be inserted in the first";
            }
            return comparisonResult;
        }
    }
}

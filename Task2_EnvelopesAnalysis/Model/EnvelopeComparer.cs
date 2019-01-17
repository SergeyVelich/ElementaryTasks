using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_EnvelopesAnalysis.Resources;

namespace Task2_EnvelopesAnalysis.Model
{
    public static class EnvelopeComparer
    {
        public static int Compare(Envelope envOut, Envelope envIn)
        {
            return envOut.CompareTo(envIn);
        }
    }
}

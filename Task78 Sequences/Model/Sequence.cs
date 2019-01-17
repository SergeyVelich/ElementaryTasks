using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model
{
    public abstract class Sequence
    {
        public int LowLimit { get; set; }
        public int UpLimit { get; set; }
        public List<int> SequenceMembers { get; private set; }

        protected abstract void GenerateSequence();

        public Sequence(int upLimit)
        {
            LowLimit = 0;
            UpLimit = upLimit;
        }

        public Sequence(int lowLimit, int upLimit)
        {
            LowLimit = lowLimit;
            UpLimit = upLimit;
        }

        public override string ToString()
        {
            StringBuilder representationBuilder = new StringBuilder();
            for (int i = 0; i < SequenceMembers.Count; i++)
            {
                representationBuilder.Append(SequenceMembers[i]);
                if (i < SequenceMembers.Count - 1)
                {
                    representationBuilder.Append(", ");
                }
            }

            return representationBuilder.ToString();
        }
    }
}

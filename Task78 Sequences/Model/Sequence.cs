using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model
{
    public abstract class Sequence
    {
        protected int _lowLimit;
        protected int _upLimit;
        protected List<int> _sequenceMembers;

        protected abstract void FillSequence();

        public Sequence()
        {
            _lowLimit = 0;
            _upLimit = 0;
            _sequenceMembers = new List<int>();
        }

        public Sequence(int upLimit) : this()
        {
            _upLimit = upLimit;
        }

        public Sequence(int lowLimit, int upLimit) : this()
        {
            _lowLimit = lowLimit;
            _upLimit = upLimit;
        }

        public override string ToString()
        {
            StringBuilder representationBuilder = new StringBuilder();
            for (int i = 0; i < _sequenceMembers.Count; i++)
            {
                representationBuilder.Append(_sequenceMembers[i]);
                if (i < _sequenceMembers.Count - 1)
                {
                    representationBuilder.Append(", ");
                }
            }

            return representationBuilder.ToString();
        }
    }
}

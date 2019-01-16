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

        protected abstract void GenerateSequence();

        public Sequence(int upLimit)
        {
            _lowLimit = 0;
            _upLimit = upLimit;
            _sequenceMembers = new List<int>();

            GenerateSequence();
        }

        public Sequence(int lowLimit, int upLimit)
        {
            _lowLimit = lowLimit;
            _upLimit = upLimit;
            _sequenceMembers = new List<int>();

            GenerateSequence();
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

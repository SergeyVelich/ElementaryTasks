using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvelopesAnalysis.Resources;

namespace EnvelopesAnalysis.Model
{
    public class EnvelopeComparer : IEnumerable
    {
        private Envelope[] _envelopes;
        public Envelope MainEnvelope { get; set; }
        public int Length { get => _envelopes.Length; }

        public EnvelopeComparer(uint quantityEnvelopes)
        {
            _envelopes = new Envelope[quantityEnvelopes - 1];
        }

        public void Insert(int position, Envelope envelope)
        {
            _envelopes[position] = envelope;
        }

        public int Compare(Envelope envIn)
        {
            return MainEnvelope.CompareTo(envIn);
        }

        public IEnumerator GetEnumerator()
        {
            return _envelopes.GetEnumerator();
        }

        public Envelope this[int index]
        {
            get
            {
                return _envelopes[index];
            }
        }
    }
}

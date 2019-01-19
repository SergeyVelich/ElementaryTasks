using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model
{
    interface ISequence
    {
        long LowLimit { get; }
        long UpLimit { get; }

        IEnumerable<long> GetSequence();
    }
}

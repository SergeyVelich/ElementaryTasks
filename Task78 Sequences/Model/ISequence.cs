using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model
{
    interface ISequence : IEnumerable
    {
        int LowLimit { get; set; }
        int UpLimit { get; set; }
    }
}

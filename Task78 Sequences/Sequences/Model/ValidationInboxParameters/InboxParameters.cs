using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Model.ValidationInboxParameters
{
    public struct InboxParams
    {
        public long LowLimit { get; set; }
        public long UpLimit { get; set; }
    }
}

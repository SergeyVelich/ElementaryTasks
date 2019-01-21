using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Resources;

namespace NumberToText.Model.ValidationInboxParameters
{
    public struct InboxParameters
    {
        public long Number { get; set; }
        public Local Region { get; set; }
        public WorkMode WorkMode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_FileParser.Resources;

namespace Task4_FileParser.Model.ValidationInboxParameters
{
    public struct InboxParameters
    {
        public WorkMode workMode { get; set; }
        public string Path { get; set; }
        public string Pattern { get; set; }
        public string Replacement { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.Resources;

namespace FileParser.Model.ValidationInboxParameters
{
    public struct InboxParameters
    {
        public string Path { get; set; }
        public string Pattern { get; set; }
        public string Replacement { get; set; }
    }
}

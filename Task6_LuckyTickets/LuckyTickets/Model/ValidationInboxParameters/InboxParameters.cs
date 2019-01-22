using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.Resources;

namespace LuckyTickets.Model.ValidationInboxParameters
{
    public struct InboxParameters
    {
        public WorkMode WorkMode { get; set; }
        public string PathLog { get; set; }
        public byte QuantityDigits { get; set; }
    }
}

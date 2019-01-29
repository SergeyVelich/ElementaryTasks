using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Resources;

namespace ChessBoard.Model.ValidationInboxParameters
{
    public struct InboxParameters
    {
        public uint Height { get; set; }
        public uint Width { get; set; }
        public WorkMode WorkMode { get; set; }
    }
}

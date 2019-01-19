using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Model
{
    interface ICell
    {
        bool IsBlack { get; }
        int CoordinateY { get; }
        int CoordinateX { get; }
    }
}

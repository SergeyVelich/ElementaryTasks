using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Model
{
    interface IBoard<ICell>
    {
        Cell[,] Cells { get; }
        int Width { get; }
        int Height { get; }
    }
}

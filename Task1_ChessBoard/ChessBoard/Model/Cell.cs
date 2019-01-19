using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Model
{
    public class Cell : ICell
    {
        public bool IsBlack { get; private set; }
        public int CoordinateY { get; private set; }
        public int CoordinateX { get; private set; }

        public Cell(int coordinateX, int coordinateY, bool firstBlack)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            IsBlack = firstBlack;
        }
    }
}

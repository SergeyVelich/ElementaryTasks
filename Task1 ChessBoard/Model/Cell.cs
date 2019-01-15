using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.Model
{
    public class Cell
    {
        public bool IsBlack { get; set; }
        public int CoordinateY { get; set; }
        public int CoordinateX { get; set; }

        public Cell(int coordinateX, int coordinateY, bool firstBlack)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            IsBlack = firstBlack;
        }
    }
}

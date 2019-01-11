using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.Model
{
    public class Cell
    {
        private int _coordinateX;
        private int _coordinateY;
        private bool _isBlack;
        private Figures _figure;

        public bool IsBlack { get => _isBlack; set => _isBlack = value; }

        public Cell(int coordinateX, int coordinateY, bool firstBlack)
        {
            _coordinateX = coordinateX;
            _coordinateY = coordinateY;
            _isBlack = firstBlack;
        }
    }
}

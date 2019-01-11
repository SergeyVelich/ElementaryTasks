using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.Model
{
    public class Board
    {
        private Cell[,] _cells;
        private int _width;
        private int _height;
        private bool _firstBlack;

        public Board(int height, int width)
        {
            _height = height;
            _width = width;           
            _firstBlack = true;

            FillBoard();
        }

        private void FillBoard()
        {
            bool isBlack;
            _cells = new Cell[_height, _width];           
            for (int y = 0; y <= _height - 1; y++)
            {
                isBlack = _firstBlack;
                for (int x = 0; x <= _width - 1; x++)
                {
                    Cell cell = new Cell(y, x, isBlack);
                    _cells[y, x] = cell;
                    isBlack = !isBlack;
                }
                _firstBlack = !_firstBlack;
            }
        }

        public override string ToString()
        {
            Cell cell;
            StringBuilder result = new StringBuilder();
            for (int y = 0; y <= _height - 1; y++)
            {
                for (int x = 0; x <= _width - 1; x++)
                {
                    cell = _cells[y, x];
                    if (cell.IsBlack)
                    {
                        result.Append("*");
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}

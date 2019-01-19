using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Resources;

namespace ChessBoard.Model
{
    public class Board : IBoard<ICell>
    {
        private bool _firstBlack;

        public Cell[,] Cells { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int height, int width)
        {
            Height = height;
            Width = width;           
            _firstBlack = true;

            Cells = GetEmptyBoard();
        }   

        private Cell[,] GetEmptyBoard()
        {
            bool isBlack = _firstBlack;
            Cell[,] cells = new Cell[Height, Width];           
            for (int y = 0; y <= Height - 1; y++)
            {
                isBlack = _firstBlack;
                for (int x = 0; x <= Width - 1; x++)
                {
                    Cell cell = new Cell(y, x, isBlack);
                    cells[y, x] = cell;
                    isBlack = !isBlack;
                }
                _firstBlack = !_firstBlack;
            }

            return cells;
        }
    }
}

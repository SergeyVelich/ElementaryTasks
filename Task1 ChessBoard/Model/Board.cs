using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ChessBoard.Resources;

namespace Task1_ChessBoard.Model
{
    public class Board
    {
        private bool _firstBlack;

        public Cell[,] Cells { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Board(int height, int width)
        {
            Height = height;
            Width = width;           
            _firstBlack = true;

            FillBoard();
        }   

        private void FillBoard()
        {
            bool isBlack;
            Cells = new Cell[Height, Width];           
            for (int y = 0; y <= Height - 1; y++)
            {
                isBlack = _firstBlack;
                for (int x = 0; x <= Width - 1; x++)
                {
                    Cell cell = new Cell(y, x, isBlack);
                    Cells[y, x] = cell;
                    isBlack = !isBlack;
                }
                _firstBlack = !_firstBlack;
            }
        }
    }
}

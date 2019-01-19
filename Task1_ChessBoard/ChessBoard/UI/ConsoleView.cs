using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Model;

namespace ChessBoard.UI
{
    class ConsoleView : IView
    {
        private const string BLOCK_SEPARATOR = "==================================================================";
        private const string CELL_COLOR_BLACK = "*";
        private const string CELL_COLOR_WHITE = " ";

        public void PrintInstructionText(string text)
        {
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine(text);
            Console.WriteLine(BLOCK_SEPARATOR);
            Console.WriteLine();
            Console.ReadKey();
        }

        public void PrintErrorText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
        }

        public void PrintResult(IBoard<ICell> board)
        {
            for (int y = 0; y <= board.Height - 1; y++)
            {
                for (int x = 0; x <= board.Width - 1; x++)
                {
                    PrintCell(board.Cells[y, x]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        public void PrintCell(ICell cell)
        {            
            if (cell.IsBlack)
            {
                Console.Write(CELL_COLOR_BLACK);
            }
            else
            {
                Console.Write(CELL_COLOR_WHITE);
            }
        }
    }
}

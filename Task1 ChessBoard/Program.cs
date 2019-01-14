using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_ChessBoard.Controller;
using Task1_ChessBoard.UI;

namespace Task1_ChessBoard
{
    class Program
    {
        public static void Main(string[] args)
        {
            IView view = new ConsoleView();
            Presenter controller = new Presenter(view);
            controller.Run(args);
        }
    }
}

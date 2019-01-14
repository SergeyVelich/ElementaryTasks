using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_TriangleSort.Controller;
using Task3_TriangleSort.UI;

namespace Task3_TriangleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            Presenter controller = new Presenter(view);
            controller.Run(args);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_FileParser.Controller;
using Task4_FileParser.UI;

namespace Task4_FileParser
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

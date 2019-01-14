using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Controller;
using Task78_Sequences.UI;

namespace Task78_Sequences
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

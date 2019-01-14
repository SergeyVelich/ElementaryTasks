using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_EnvelopesAnalysis.Controller;
using Task2_EnvelopesAnalysis.UI;

namespace Task2_EnvelopesAnalysis
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

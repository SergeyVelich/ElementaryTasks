using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_LuckyTickets.Controller;
using Task6_LuckyTickets.UI;

namespace Task6_LuckyTickets
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Model;
using NumberToText.Controller;
using NumberToText.UI;

namespace NumberToText
{
    public class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            Presenter controller = new Presenter(view);
            controller.Run(args);           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_LuckyTickets.Model;
using Task6_LuckyTickets.Model.ValidationInboxParameters;
using Task6_LuckyTickets.UI;
using Task6_LuckyTickets.Resources;
using System.IO;

namespace Task6_LuckyTickets.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;
        private bool _run;
        private string _path;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            LuckyTicketsGenerator lackyGenerator = null;

            _view.SetPath += OnSetPath;
            _view.EndWork += OnEndWork;

            if (args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.instruction);
            }

            try
            {
                _inboxParameters = new MainParamValidator(args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            do
            {
                bool isFailed = false;
                do
                {
                    try
                    {
                        _view.AskInputPath("Enter path file with metod: ");
                        lackyGenerator = new LuckyTicketsGenerator(_path);
                        isFailed = false;
                    }
                    catch (Exception ex)
                    {
                        _view.PrintErrorText(ex.Message);
                        isFailed = true;
                    }
                } while (isFailed);

                lackyGenerator.Generate();
                _view.PrintAnswerText(lackyGenerator.Count().ToString());
                _view.AskContinue("Do you want to continue? yes(y)/no(n)");

            } while (_run);
        }

        protected virtual void OnSetPath(object sender, EventArgs e)
        {
            if (!File.Exists(((StringEventArgs)e).Value))
            {
                throw new ArgumentException("Error");
            }
            _path = ((StringEventArgs)e).Value;
        }

        protected virtual void OnEndWork(object sender, EventArgs e)
        {
            _run = ((StringEventArgs)e).Value.ToLower().Trim() == "y" || ((StringEventArgs)e).Value.ToLower().Trim() == "yes";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_FileParser.Model;
using Task4_FileParser.Model.ValidationInboxParameters;
using Task4_FileParser.UI;
using Task4_FileParser.Resources;

namespace Task4_FileParser.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            int result;
            Parser parser;

            if (args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
                return;
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

            parser = new Parser(_inboxParameters.Path);
            try
            {
                switch (_inboxParameters.workMode)
                {
                    case Resources.WorkMode.FindMode:
                        result = parser.GetCountFinded(_inboxParameters.Pattern);                    
                        break;
                    case Resources.WorkMode.ReplaceMode:
                        result = parser.GetCountReplaced(_inboxParameters.Pattern, _inboxParameters.Replacement);
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            Console.ReadKey();
        }
    }
}

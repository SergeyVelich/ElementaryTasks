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
            WorkMode workMode;

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

            if (args.Length == 2)
            {
                workMode = WorkMode.SearchMode;
            }
            else
            {
                workMode = WorkMode.ReplaceMode;
            }

            parser = new Parser(_inboxParameters.Path);
            try
            {
                switch (workMode)
                {
                    case WorkMode.SearchMode:
                        result = parser.GetCountFinded(_inboxParameters.Pattern);
                        _view.PrintResultText(String.Format(MessagesResources.ResultSearchMode, result));
                        break;
                    case WorkMode.ReplaceMode:
                        result = parser.GetCountReplaced(_inboxParameters.Pattern, _inboxParameters.Replacement);
                        _view.PrintResultText(String.Format(MessagesResources.ResultReplaceMode, result));
                        break;
                    default:
                        throw new Exception(MessagesResources.ErrorInvalidWorkMode);
                }
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }
        }
    }
}

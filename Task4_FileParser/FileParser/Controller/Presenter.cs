using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.Model;
using FileParser.Model.ValidationInboxParameters;
using FileParser.UI;
using FileParser.Resources;

namespace FileParser.Controller
{
    class Presenter
    {
        private IView _view;
        private string[] _args;
        private InboxParameters _inboxParameters;
        private WorkMode _workMode;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            _args = args;

            if (_args.Length == 0)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
                return;
            }

            try
            {
                _inboxParameters = new MainParamValidator(_args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }

            _workMode = GetWorkMode();

            int result;
            Parser parser = new Parser(_inboxParameters.Path);
            try
            {
                switch (_workMode)
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

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 2)
            {
                workMode = WorkMode.SearchMode;
            }
            else
            {
                workMode = WorkMode.ReplaceMode;
            }

            return workMode;
        }
    }
}

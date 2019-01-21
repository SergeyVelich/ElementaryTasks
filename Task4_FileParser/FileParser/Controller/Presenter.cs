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
        private InboxParameters _inboxParams;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            _view.PrintTitleText(MessagesResources.ApplicationName);

            try
            {
                _inboxParams = new MainParamValidator(args).GetMainParameters();
            }
            catch (Exception ex)
            {
                _view.PrintErrorText(ex.Message);
                return;
            }
            if (_inboxParams.WorkMode == WorkMode.HelpMode)
            {
                _view.PrintInstructionText(MessagesResources.Instruction);
                return;
            }

            int result;
            ParserTxt parser = new ParserTxt(_inboxParams.Path);

            switch (_inboxParams.WorkMode)
            {
                case WorkMode.SearchMode:
                    result = parser.GetCountFinded(_inboxParams.Pattern);
                    _view.PrintResultText(String.Format(MessagesResources.ResultSearchMode, result));
                    break;
                case WorkMode.ReplaceMode:
                    result = parser.GetCountReplaced(_inboxParams.Pattern, _inboxParams.Replacement);
                    _view.PrintResultText(String.Format(MessagesResources.ResultReplaceMode, result));
                    break;
                default:
                    _view.PrintErrorText(MessagesResources.ErrorInvalidWorkMode);
                    return;
            }
        }
    }
}

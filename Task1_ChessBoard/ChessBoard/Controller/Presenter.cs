using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Model;
using ChessBoard.Model.ValidationInboxParameters;
using ChessBoard.UI;
using ChessBoard.Resources;

namespace ChessBoard.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParams;

        public Presenter(IView view)
        {
            _view = view;
        }

        public virtual void Run(string[] args)
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

            _view.PrintResult(new Board(_inboxParams.Height, _inboxParams.Width));
        }
    }
}

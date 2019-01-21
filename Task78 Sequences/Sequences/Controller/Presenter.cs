using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Model;
using Sequences.Model.ValidationInboxParameters;
using Sequences.UI;
using Sequences.Resources;

namespace Sequences.Controller
{
    class Presenter
    {       
        private IView _view;
        private InboxParams _inboxParams;

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

            ISequence sequence;
            switch (_inboxParams.WorkMode)
            {
                case WorkMode.FibonaccіMode:
                    sequence = new FiboSequence(_inboxParams.LowLimit, _inboxParams.UpLimit);
                    _view.PrintResult(String.Format(MessagesResources.ResultFibonacciMode, _inboxParams.LowLimit, _inboxParams.UpLimit), sequence.GetSequence());
                    break;
                case WorkMode.PowMode:
                    sequence = new PowSequence(_inboxParams.UpLimit);
                    _view.PrintResult(String.Format(MessagesResources.ResultPowMode, _inboxParams.LowLimit, _inboxParams.UpLimit), sequence.GetSequence());
                    break;
                default:
                    _view.PrintErrorText(MessagesResources.ErrorInvalidWorkMode);
                    return;
            }
        }
    }
}

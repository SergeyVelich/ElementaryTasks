using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Model;
using Task78_Sequences.Model.ValidationInboxParameters;
using Task78_Sequences.UI;
using Task78_Sequences.Resources;

namespace Task78_Sequences.Controller
{
    class Presenter
    {
        private IView _view;
        private InboxParameters _inboxParameters;
        private WorkMode _workMode;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {                        
            Sequence sequence;

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

            if (args.Length == 1)
            {
                _workMode = WorkMode.PowMode;
            }
            else
            {
                _workMode = WorkMode.FibonaccіMode;
            }

            try
            {
                switch (_workMode)
                {
                    case WorkMode.FibonaccіMode:
                        sequence = new FiboSequence(_inboxParameters.LowLimit, _inboxParameters.UpLimit);
                        _view.PrintResultText(String.Format(MessagesResources.ResultFibonacciMode, _inboxParameters.LowLimit, _inboxParameters.UpLimit) + sequence.ToString());
                        break;
                    case WorkMode.PowMode:
                        sequence = new PowSequence(_inboxParameters.UpLimit);
                        _view.PrintResultText(String.Format(MessagesResources.ResultPowMode, _inboxParameters.LowLimit, _inboxParameters.UpLimit) + sequence.ToString());
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

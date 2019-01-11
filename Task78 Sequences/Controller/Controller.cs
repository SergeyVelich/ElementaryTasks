using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Model;
using Task78_Sequences.Model.ValidationInboxParameters;
using Task78_Sequences.Representation;

namespace Task78_Sequences.Controller
{
    class Presenter
    {
        IView _view;

        public Presenter(IView view)
        {
            _view = view;
        }

        public void Run(string[] args)
        {
            string viewText;
            if (args.Length == 0)
            {
                viewText = "instruction";
                _view.PrintInstructionText(viewText);
                return;
            }

            MainParamValidator paramValidator = new MainParamValidator();
            InboxParameters inboxParameters = paramValidator.GetMainParameters(args);

            if (!inboxParameters.IsValid)
            {
                _view.PrintErrorText(inboxParameters.ErrorText);
                return;
            }

            Sequence sequence;

            sequence = new FiboSequence(inboxParameters.LowLimit, inboxParameters.UpLimit);
            sequence.FillSequence();

            viewText = String.Format("Fibonacci sequence from {0} to {1}: ", inboxParameters.LowLimit, inboxParameters.UpLimit) + sequence.ToString();
            _view.PrintAnswer(viewText);

            sequence = new PowSequence(inboxParameters.UpLimit);
            sequence.FillSequence();

            viewText = String.Format("Pow sequence from {0} to {1}: ", inboxParameters.LowLimit, inboxParameters.UpLimit) + sequence.ToString();
            _view.PrintAnswer(viewText);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_StringNumber.Model;
using Task5_StringNumber.Model.ValidationInboxParameters;
using Task5_StringNumber.Representation;

namespace Task5_StringNumber.Controller
{
    class Presenter
    {
        private IView _view;

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

            ConverterToText converter = GetConverter(inboxParameters.Region);
            if (converter == null)
            {
                viewText = "";
                _view.PrintErrorText(viewText);
                return;
            }
            viewText = String.Format("{0} = {1}", inboxParameters.Number, converter.Convert(inboxParameters.Number));
            _view.PrintAnswer(viewText);
        }

        public ConverterToText GetConverter(Local local)
        {
            ConverterToText converter;
            switch (local)
            {
                case Local.EN:
                    converter = new ConverterToTextEN();
                    break;
                case Local.RU:
                    converter = new ConverterToTextRU();
                    break;
                case Local.UA:
                    converter = new ConverterToTextUA();
                    break;
                default:
                    converter = null;
                    break;
            }
            return converter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToText.Model;
using NumberToText.Model.ValidationInboxParameters;
using NumberToText.UI;
using NumberToText.Resources;

namespace NumberToText.Controller
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

            ConverterToText converter = GetConverter(_inboxParams.Region);
            if (converter == null)
            {
                _view.PrintErrorText(MessagesResources.ErrorConverterNotFound);
                return;
            }

            _view.PrintResultText(String.Format(MessagesResources.Result, _inboxParams.Number, converter.Convert(_inboxParams.Number)));
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

using System;

using NumberToText.Resources;

namespace NumberToText.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        private readonly string[] _args;

        public MainParamValidator(string[] args)
        {
            _args = args;
        }

        public InboxParameters GetMainParameters()
        {
            InboxParameters inboxParams = new InboxParameters();
            inboxParams.WorkMode = GetWorkMode();
            if (inboxParams.WorkMode == WorkMode.HelpMode)
            {
                return inboxParams;
            }

            if (_args.Length < 1)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorArgumentNotFoundArgument, _args.Length + 1));
            }

            if (!long.TryParse(_args[0], out long number))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }
            else if (Math.Abs(number)>= Math.Pow(10, ConverterToText.MAX_RANK))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
            }

            Local region = Local.RU;

            if (_args.Length > 1)
            {
                if (Enum.IsDefined(typeof(Local), _args[1]))
                {
                    region = (Local)Enum.Parse(typeof(Local), _args[1]);
                }
                else
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidLocal);
                }
            }

            inboxParams.Region = region;
            inboxParams.Number = number;            

            return inboxParams;
        }

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 0)
            {
                workMode = WorkMode.HelpMode;
            }
            else
            {
                workMode = WorkMode.MainMode;
            }

            return workMode;
        }
    }
}

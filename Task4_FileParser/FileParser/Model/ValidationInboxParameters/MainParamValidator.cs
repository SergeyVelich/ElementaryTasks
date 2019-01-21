using System;
using System.IO;
using FileParser.Resources;

namespace FileParser.Model.ValidationInboxParameters
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

            if (_args.Length < 2)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorArgumentNotFoundArgument, _args.Length + 1));
            }

            if (!File.Exists(_args[0]))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorFileNotFound, _args[0]));
            }
            inboxParams.Path = _args[0];

            inboxParams.Pattern = _args[1];
            if (inboxParams.WorkMode == WorkMode.SearchMode)
            {

            }
            else if (inboxParams.WorkMode == WorkMode.ReplaceMode)
            {
                inboxParams.Replacement = _args[2];
            }
            else
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidWorkMode);
            }

            return inboxParams;
        }

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 0)
            {
                workMode = WorkMode.HelpMode;
            }
            else if (_args.Length == 2)
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

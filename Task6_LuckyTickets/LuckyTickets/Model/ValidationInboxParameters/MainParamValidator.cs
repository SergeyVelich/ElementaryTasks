using System;
using LuckyTickets.Resources;

namespace LuckyTickets.Model.ValidationInboxParameters
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

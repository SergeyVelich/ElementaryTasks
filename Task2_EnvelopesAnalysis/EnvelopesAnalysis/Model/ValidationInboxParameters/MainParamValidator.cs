using System;
using EnvelopesAnalysis.Resources;

namespace EnvelopesAnalysis.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        private readonly uint QUANTITY_ENVELOPES = 2;
        private readonly string[] _args;

        public MainParamValidator(string[] args)
        {            
            _args = args;
        }

        public InboxParameters GetMainParameters()
        {
            InboxParameters inboxParams = new InboxParameters();
            inboxParams.WorkMode = GetWorkMode();
            inboxParams.QuantityEnvelopes = QUANTITY_ENVELOPES;

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

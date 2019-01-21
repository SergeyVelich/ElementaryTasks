using System;
using Sequences.Resources;

namespace Sequences.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        private readonly string[] _args;

        public MainParamValidator(string[] args)
        {
            _args = args;
        }

        public InboxParams GetMainParameters()
        {
            InboxParams inboxParams = new InboxParams();
            inboxParams.WorkMode = GetWorkMode();
            if (inboxParams.WorkMode == WorkMode.HelpMode)
            {
                return inboxParams;
            }

            long lowLimit = 0;
            long upLimit = 0;

            if (inboxParams.WorkMode == WorkMode.PowMode)
            {
                if (!long.TryParse(_args[0], out upLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
                }
                if (upLimit <= 0)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentPowNegative);
                }
            }
            else if(inboxParams.WorkMode == WorkMode.FibonaccіMode)
            {
                if (!long.TryParse(_args[0], out lowLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
                }
                if (!long.TryParse(_args[1], out upLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
                }
                if (lowLimit < 0)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentFiboNegative);
                }
                else if (upLimit < lowLimit)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentFiboMixLimits);
                }
            }
            else
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidWorkMode);
            }

            inboxParams.LowLimit = lowLimit;
            inboxParams.UpLimit = upLimit;

            return inboxParams;
        }

        private WorkMode GetWorkMode()
        {
            WorkMode workMode;

            if (_args.Length == 0)
            {
                workMode = WorkMode.HelpMode;
            }
            else if (_args.Length == 1)
            {
                workMode = WorkMode.PowMode;
            }
            else
            {
                workMode = WorkMode.FibonaccіMode;
            }

            return workMode;
        }
    }
}

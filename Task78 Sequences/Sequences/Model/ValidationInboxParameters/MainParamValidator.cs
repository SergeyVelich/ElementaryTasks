using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            int lowLimit = 0;
            int upLimit = 0;

            if (_args.Length == 1)
            {
                if (!int.TryParse(_args[0], out upLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
                }
                if (upLimit < 0)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentPowNegative);
                }
            }
            else
            {
                if (!int.TryParse(_args[0], out lowLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 1));
                }
                if (!int.TryParse(_args[1], out upLimit))
                {
                    throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
                }
                if (upLimit <= 0)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentFiboNegative);
                }
                else if (upLimit < lowLimit)
                {
                    throw new ArgumentException(MessagesResources.ErrorInvalidArgumentFiboMixLimits);
                }
            }

            inboxParams.LowLimit = lowLimit;
            inboxParams.UpLimit = upLimit;

            return inboxParams;
        }
    }
}

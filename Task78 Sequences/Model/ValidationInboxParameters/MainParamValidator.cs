using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task78_Sequences.Resources;

namespace Task78_Sequences.Model.ValidationInboxParameters
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
            InboxParameters inboxParameters = new InboxParameters();

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

            inboxParameters.LowLimit = lowLimit;
            inboxParameters.UpLimit = upLimit;

            return inboxParameters;
        }
    }
}

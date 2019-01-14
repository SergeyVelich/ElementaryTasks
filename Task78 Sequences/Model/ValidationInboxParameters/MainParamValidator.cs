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

            if (!int.TryParse(_args[0], out int lowLimit))
            {
                throw new ArgumentException(MessagesResources.InvalidArgument1);
            }
            if (!int.TryParse(_args[1], out int upLimit))
            {
                throw new ArgumentException(MessagesResources.InvalidArgument2);
            }

            if (_args.Length == 1)
            {
                if (upLimit < 0)
                {
                    throw new ArgumentException(MessagesResources.InvalidArgumentPowNegative);
                }
            }
            else if (_args.Length > 1)
            {
                if (upLimit <= 0)
                {
                    throw new ArgumentException(MessagesResources.InvalidArgumentFiboNegative);
                }
                else if (upLimit < lowLimit)
                {
                    throw new ArgumentException(MessagesResources.InvalidArgumentFiboMixLimits);
                }
            }

            inboxParameters.LowLimit = lowLimit;
            inboxParameters.UpLimit = upLimit;

            return inboxParameters;
        }
    }
}

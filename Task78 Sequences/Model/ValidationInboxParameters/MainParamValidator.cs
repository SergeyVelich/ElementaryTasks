using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task78_Sequences.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        public InboxParameters GetMainParameters(string[] args)
        {
            int lowLimit = 0;
            int upLimit = 0;

            InboxParameters inboxParameters = new InboxParameters();
            inboxParameters.IsValid = true;
            inboxParameters.ErrorText = "";

            if (args.Length < 2)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (!int.TryParse(args[0], out lowLimit))
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (lowLimit == 0)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (lowLimit > int.MaxValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (!int.TryParse(args[1], out upLimit))
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (upLimit < lowLimit)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (upLimit > int.MaxValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            inboxParameters.LowLimit = lowLimit;
            inboxParameters.UpLimit = upLimit;

            return inboxParameters;
        }
    }
}

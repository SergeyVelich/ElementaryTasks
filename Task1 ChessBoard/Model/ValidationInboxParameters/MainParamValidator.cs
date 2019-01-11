using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ChessBoard.Model.ValidationInboxParameters
{
    public class MainParamValidator
    {
        public InboxParameters GetMainParameters(string[] args)
        {
            int height = 0;
            int width = 0;

            InboxParameters inboxParameters = new InboxParameters();
            inboxParameters.IsValid = true;
            inboxParameters.ErrorText = "";

            if (args.Length < 2)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (!int.TryParse(args[0], out height))
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (height <= 0)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (height > int.MaxValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            if (!int.TryParse(args[1], out width))
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (height <= 0)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }
            else if (width > int.MaxValue)
            {
                inboxParameters.IsValid = false;
                inboxParameters.ErrorText = "Property cannot be null or empty";
            }

            inboxParameters.Height = height;
            inboxParameters.Width = width;

            return inboxParameters;
        }
    }
}

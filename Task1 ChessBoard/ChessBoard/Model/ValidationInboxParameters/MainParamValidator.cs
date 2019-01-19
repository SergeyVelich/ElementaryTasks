using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBoard.Resources;

namespace ChessBoard.Model.ValidationInboxParameters
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

            if (_args.Length < 2)
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorArgumentNotFoundArgument, _args.Length + 1));
            }

            if (!int.TryParse(_args[0], out int height))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
            }
            else if (height <= 0)
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgumentNegative);
            }

            if (!int.TryParse(_args[1], out int width))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
            }
            else if (height <= 0)
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgumentNegative);
            }

            inboxParameters.Height = height;
            inboxParameters.Width = width;

            return inboxParameters;
        }
    }
}

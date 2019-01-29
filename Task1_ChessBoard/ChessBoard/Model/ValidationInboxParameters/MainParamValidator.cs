using System;
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

            if (!uint.TryParse(_args[0], out uint height))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
            }
            else if (height <= 0)
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgumentNegative);
            }

            if (!uint.TryParse(_args[1], out uint width))
            {
                throw new ArgumentException(String.Format(MessagesResources.ErrorInvalidArgument, 2));
            }
            else if (width <= 0)
            {
                throw new ArgumentException(MessagesResources.ErrorInvalidArgumentNegative);
            }

            inboxParams.Height = height;
            inboxParams.Width = width;

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

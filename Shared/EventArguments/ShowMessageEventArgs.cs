using System;

namespace Shared.EventArguments
{
    public class ShowMessageEventArgs : System.EventArgs
    {
        public string Message { get; }
        public bool IsError { get; }

        public ShowMessageEventArgs(string message, bool isError = false)
        {
            Message = message;
            IsError = isError;
        }
    }
}
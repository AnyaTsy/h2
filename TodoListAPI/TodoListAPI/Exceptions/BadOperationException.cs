using System;

namespace TodoListAPI.Exceptions
{
    public class BadOperationException : Exception
    {
        public BadOperationException(string message)
            : base(message)
        {
        }
    }
}

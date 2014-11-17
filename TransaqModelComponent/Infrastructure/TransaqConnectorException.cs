using System;

namespace TransaqModelComponent.Infrastructure
{
    public sealed class TransaqConnectorException : Exception
    {
        public TransaqConnectorException(string message) 
            : base(message)
        { }

        public TransaqConnectorException()
        {
            // TODO: Complete member initialization
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace Mk0.Tools.SQLiteTools
{
    [Serializable]
    internal class SQLiteToolsException : Exception
    {
        public SQLiteToolsException()
        {
        }

        public SQLiteToolsException(string message) : base(message)
        {
        }

        public SQLiteToolsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SQLiteToolsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

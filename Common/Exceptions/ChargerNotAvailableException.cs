using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ChargerNotAvailableException : Exception
    {
        public ChargerNotAvailableException()
        {
        }

        public ChargerNotAvailableException(string? message) : base(message)
        {
        }

        public ChargerNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChargerNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

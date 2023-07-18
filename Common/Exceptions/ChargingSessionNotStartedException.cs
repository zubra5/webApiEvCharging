using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ChargingSessionNotStartedException : Exception
    {
        public ChargingSessionNotStartedException()
        {
        }

        public ChargingSessionNotStartedException(string? message) : base(message)
        {
        }

        public ChargingSessionNotStartedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChargingSessionNotStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

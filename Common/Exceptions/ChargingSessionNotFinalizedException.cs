using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ChargingSessionNotFinalizedException : Exception
    {
        public ChargingSessionNotFinalizedException()
        {
        }

        public ChargingSessionNotFinalizedException(string? message) : base(message)
        {
        }

        public ChargingSessionNotFinalizedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChargingSessionNotFinalizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

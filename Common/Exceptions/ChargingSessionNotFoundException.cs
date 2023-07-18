using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ChargingSessionNotFoundException : Exception
    {
        public ChargingSessionNotFoundException()
        {
        }

        public ChargingSessionNotFoundException(string? message) : base(message)
        {
        }

        public ChargingSessionNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChargingSessionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ReservationNotFoundException : Exception, INotFoundException
    {
        public ReservationNotFoundException()
        {
        }

        public ReservationNotFoundException(string? message) : base(message)
        {
        }

        public ReservationNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

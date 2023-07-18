using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ReservationCanNotCancelException : Exception
    {
        public ReservationCanNotCancelException()
        {
        }

        public ReservationCanNotCancelException(string? message) : base(message)
        {
        }

        public ReservationCanNotCancelException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationCanNotCancelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

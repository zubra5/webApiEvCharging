using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class ChargerNotFoundException : Exception, INotFoundException
    {
        public ChargerNotFoundException()
        {
        }

        public ChargerNotFoundException(string? message) : base(message)
        {
        }

        public ChargerNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ChargerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

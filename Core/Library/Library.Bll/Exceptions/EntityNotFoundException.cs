using System;

namespace Library.Bll.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private static readonly string MESSAGE = "Wasn't possible find requested resource";
        private static readonly string MESSAGE_RESOURCE = "Wasn't possible find requested resource! - {0}";

        public EntityNotFoundException() : base(MESSAGE) { }

        public EntityNotFoundException(string resource) : base(string.Format(MESSAGE_RESOURCE, resource))
        { }

        public EntityNotFoundException(string resource, Exception innerException) : base(string.Format(MESSAGE_RESOURCE, resource), innerException)
        { }
    }
}

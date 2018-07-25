using System;

namespace Library.Bll.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private static readonly string MESSAGE = "Não foi possível encontrar o recurso solicitado!";
        private static readonly string MESSAGE_RESOURCE = "Não foi possível encontrar o recurso {0} solicitado!";

        public EntityNotFoundException() : base(MESSAGE) { }

        public EntityNotFoundException(string resource) : base(string.Format(MESSAGE_RESOURCE, resource))
        { }

        public EntityNotFoundException(string resource, Exception innerException) : base(string.Format(MESSAGE_RESOURCE, resource), innerException)
        { }
    }
}

using System;

namespace Library.Bll.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base("Operação inválida!")
        { }

        public BusinessException(string message) : base(message)
        { }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}

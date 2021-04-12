using System;
using System.Collections.Generic;

namespace CustomerApiWithService.Application.Exceptions
{
    public class RepositoryException : AppException
    {
        // Fields
        private const string _message = "Falha ao processar o repositório de dados";

        // Ctors
        public RepositoryException() : this(_message)
        {
        }

        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(IList<string> messageList) : base(messageList)
        {
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RepositoryException(System.Exception innerException) : base(_message, innerException)
        {
        }
    }
}

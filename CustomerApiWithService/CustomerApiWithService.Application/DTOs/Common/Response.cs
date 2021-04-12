using System.Collections.Generic;

namespace CustomerApiWithService.Application.DTOs.Common
{
    public class Response<T> : Response
    {
        // Properties
        public T Data { get; set; }

        // Ctors
        public Response(bool succeeded, string message, List<string> errors, T data) : base(succeeded, message, errors)
        {
            Data = data;
        }

        public Response(bool succeeded, List<string> errors, T data) : base(succeeded, errors)
        {
            Data = data;
        }


        public Response(bool succeeded, List<string> errors) : base(succeeded, errors)
        {
        }

        public Response(bool succeeded, T data) : base(succeeded, null)
        {
            Data = data;
        }

    }

    public class Response
    {
        // Properties
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        // Ctors
        public Response(bool succeeded, string message, List<string> errors)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = errors;
        }

        public Response(bool succeeded, List<string> errors)
        {
            Succeeded = succeeded;
            Message = succeeded ? "Solicitação processada com sucesso" : "Falha ao processar a solicitação";
            Errors = errors;
        }

        public Response(bool succeeded) : this(succeeded, null)
        {
        }

        public void AddError(string error)
        {
            if (Errors is null)
                Errors = new List<string>();

            Errors.Add(error);
        }
    }
}

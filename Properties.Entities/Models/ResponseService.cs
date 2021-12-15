using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Entities.Models
{
    public class ResponseService<T>
    {

        public ResponseService(bool hasError, string message, HttpStatusCode statusCode, T content)
        {
            HasError = hasError;
            Message = message;
            StatusHttp = statusCode;
            Content = content;
        }

        public bool HasError { get; set; } = false;
        public string Message { get; set; } = "";
        public HttpStatusCode StatusHttp { get; set; } = HttpStatusCode.OK;
        public T Content { get; set; }

    }

}

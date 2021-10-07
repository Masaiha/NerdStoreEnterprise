using System;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpRequestException : Exception
    {

        public HttpStatusCode _statusCode;

        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string message, Exception exception) : base(message, exception) { }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

    }
}

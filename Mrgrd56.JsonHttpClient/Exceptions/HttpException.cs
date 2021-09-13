using System;
using System.Net.Http;

namespace Mrgrd56.JsonHttpClient.Exceptions
{
    public class HttpException : Exception
    {
        public HttpResponseMessage Response { get; }

        public HttpException(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
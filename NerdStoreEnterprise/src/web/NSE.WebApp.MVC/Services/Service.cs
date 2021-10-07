
using NSE.WebApp.MVC.Extensions;
using System;
using System.Net.Http;

namespace NSE.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected bool TratarErrosResponse(HttpResponseMessage httpResponse)
        {
            switch ((int)httpResponse.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(httpResponse.StatusCode);

                case 400:
                    return false;
            }

            httpResponse.EnsureSuccessStatusCode();
            return true;
        }
    }
}

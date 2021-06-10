using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payment.MVC.Extensions
{
    public static class HttpRequestMessageExtension
    {
        public static string GetClientIp(this HttpContext request)
        {
            if(request != null)
            {
                return request.Connection.RemoteIpAddress.ToString();
            }
            return string.Empty;
        }
    }
}

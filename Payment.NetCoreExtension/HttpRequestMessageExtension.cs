using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Payment.NetCoreExtension
{
    public static class HttpRequestMessageExtension
    {
        public static string GetClientIp(this HttpContext request)
        {
            if (request != null)
            {
                return request.Connection.RemoteIpAddress.ToString();
            }
            return string.Empty;
        }

        public static string GetClaim(this HttpContext httpContext, string claimName)
        {
            var claimIdentity = httpContext.User.Claims as ClaimsIdentity;
            
            if(claimIdentity != null)
            {
                var claimValue = claimIdentity.FindFirst(claimName);
                return claimValue.Value;
            }

            return null;
        }
    }
}

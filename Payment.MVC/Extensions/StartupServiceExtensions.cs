using Microsoft.Extensions.DependencyInjection;
using Payment.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Extensions
{
    public static class StartupServiceExtensions
    {
        public static void AddConnectedService(this IServiceCollection services)
        {
            services.AddScoped<IVNPayService, VNPayService>();
        }
    }
}

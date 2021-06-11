using Microsoft.Extensions.DependencyInjection;
using Payment.Data.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Context
{
    public static class AppDbContextExtensions
    {
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitialize = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitialize.Initialize();
            }
        }

        public static void AddDefault(this IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitialize = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitialize.AddDefautlUser();
            }
        }
    }
}

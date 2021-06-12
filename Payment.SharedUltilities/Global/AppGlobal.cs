using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.SharedUltilities.Global
{
    public class AppGlobal
    {
        #region Default Value
        public static string DefaultStringCode => DateTime.Now.Ticks.ToString();
        public static string DefaultOrderStatusCode
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Defaults")
                    .GetSection("DefaultOrderStatusCode").Value;
            }
        }
        public static string DefaultPaymentSuccessMessage
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Defaults")
                    .GetSection("DefaultPaymentSuccessMessage").Value;
            }
        }
        public static string DefaultInvalidSignatureMessage
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Defaults")
                    .GetSection("DefaultInvalidSignatureMessage").Value;
            }
        }
        public static string PaymentSuccessOrderStatusCode
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Defaults")
                    .GetSection("PaymentSuccessOrderStatusCode").Value;
            }
        }
        public static string PaymentFailOrderStatusCode
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("Defaults")
                    .GetSection("PaymentFailOrderStatusCode").Value;
            }
        }
        #endregion

        #region VNPay
        public static string VNP_ReturnUrl
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_ReturnUrl").Value;
            }
        }
        public static string VNP_Url
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_Url").Value;
            }
        }
        public static string VNP_TMNCode
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_TMNCode").Value;
            }
        }
        public static string VNP_HashSecret
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_HashSecret").Value;
            }
        }
        public static string VNP_Version
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_Version").Value;
            }
        }
        public static string VNP_CurrCode
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("VNPay")
                    .GetSection("VNP_CurrCode").Value;
            }
        }
        #endregion
    }
}

using Payment.SharedUltilities.Extensions;
using Payment.SharedUltilities.Global;
using Payment.SharedUltilities.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Payment.ExternalService
{
    public interface IVNPayService
    {
        public string GetPaymentRedirectUrl(VNPayRequestModel request);
    }

    public class VNPayService : IVNPayService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public VNPayService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public string GetPaymentRedirectUrl(VNPayRequestModel request)
        {
            string BaseAddress = AppGlobal.VNP_Url;
            string queryString = request.ToQueryStringData();
            string rawData = request.ToQueryStringRawData();
            string url = "?" + queryString + "vnp_SecureHash="
                + SecurityHelper.Sha256(AppGlobal.VNP_HashSecret + rawData);
            return BaseAddress + url;
        }
    }
}

using Payment.SharedUltilities.Extensions;
using Payment.SharedUltilities.Global;
using Payment.SharedUltilities.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Payment.ExternalService
{
    public interface IVNPayService
    {
        public string GetPaymentRedirectUrl(VNPayRequestModel request);

        public string GetPaymentRedirectUrl(SortedList<String, String> requestData);
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

        public string GetPaymentRedirectUrl(SortedList<string, string> requestData)
        {
            string BaseAddress = AppGlobal.VNP_Url;
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in requestData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(kv.Key + "=" + HttpUtility.UrlEncode(kv.Value) + "&");
                }
            }
            string queryString = data.ToString();
            string rawData = requestData.GetRawData();
            BaseAddress += "?" + queryString;
            string vnp_SecureHash = SecurityHelper.Sha256(AppGlobal.VNP_HashSecret + rawData);
            BaseAddress += "vnp_SecureHash=" + vnp_SecureHash;
            return BaseAddress;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Payment.ExternalService.HDInsurance
{
    public interface IHDIService
    {

    }
    public class HDIService : IHDIService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HDIService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
    }
}

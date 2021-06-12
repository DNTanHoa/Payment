using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Entities
{
    public class PaymentLog : BaseEntity
    {
        public int id { get; set; }
        public string tmnCode { get; set; }
        public decimal amount { get; set; }
        public string bankCode { get; set; }
        public string bankTranNo { get; set; }
        public string cardType { get; set; }
        public DateTime payDate { get; set; }
        public string orderInfor { get; set; }
        public string transactionNo { get; set; }
        public string responseCode { get; set; }
        public string txnRef { get; set; }
        public string secureHash { get; set; }
    }
}

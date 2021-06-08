using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Entities
{
    public class OrderInfor : BaseEntity
    {
        public string orderId { get; set; }
        public string orderDescription { get; set; }
        public decimal amount { get; set; }
        public Bank bank { get; set; }
        public OrderStatus status { get; set; }

        #region Payment Info
        public string transactionNo { get; set; }
        public string message { get; set; }
        public string responseCode { get; set; }
        #endregion
    }
}

using Payment.Data.Entities;
using Payment.SharedUltilities.Extensions;
using Payment.SharedUltilities.Global;
using Payment.SharedUltilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Extensions
{
    public static class OrderInforExtensions
    {
        public static void SetDefaultValue(this OrderInfor order)
        {
            if (string.IsNullOrEmpty(order.orderId))
            {
                order.orderId = AppGlobal.DefaultStringCode;
            }
        }

        public static bool SetOrderStatus(this OrderInfor order, OrderStatus status)
        {
            if (status != null)
            {
                order.status = status;
                return true;
            }
            return false;
        }

        public static SortedList<string, string> ToPaymentRequestData(this OrderInfor order, string clientIp, string language)
        {
            var requestData = new SortedList<string, string>(new VNPayCompare());

            requestData.AddData("vnp_Version", AppGlobal.VNP_Version);
            requestData.AddData("vnp_Command", "pay");
            requestData.AddData("vnp_TmnCode", AppGlobal.VNP_TMNCode);
            requestData.AddData("vnp_Locale", language);
            requestData.AddData("vnp_CurrCode", "VND");
            requestData.AddData("vnp_TxnRef", order.orderId);
            requestData.AddData("vnp_OrderInfo", order.orderDescription);
            requestData.AddData("vnp_OrderType", "topup");
            requestData.AddData("vnp_Amount", (order.amount * 100).ToString());
            requestData.AddData("vnp_ReturnUrl", AppGlobal.VNP_ReturnUrl);
            requestData.AddData("vnp_IpAddr", clientIp);
            requestData.AddData("vnp_CreateDate", order.createdAt.ToString("yyyyMMddHHmmss"));

            if(order.bank != null)
            {
                requestData.AddData("vnp_BankCode", order.bank.bankCode);
            }

            return requestData;
        }
    }
}

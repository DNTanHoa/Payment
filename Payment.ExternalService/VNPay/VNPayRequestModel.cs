using Payment.SharedUltilities.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.ExternalService
{
    public class VNPayRequestModel
    {
        public VNPayRequestModel(bool setDefaultValue = false)
        {
            if (setDefaultValue)
            {
                this.vnp_Version = AppGlobal.VNP_Version;
                this.vnp_TmnCode = AppGlobal.VNP_TMNCode;
                this.vnp_ReturnUrl = AppGlobal.VNP_ReturnUrl;
                this.vnp_CurrCode = AppGlobal.VNP_CurrCode;
                //this.vnp_SecureHashType = "SHA256";
            }
        }
        public string vnp_Version { get; set; }
        public string vnp_Command { get; set; }
        public string vnp_TmnCode { get; set; }
        public string vnp_Locale { get; set; }
        public string vnp_CurrCode { get; set; }
        public string vnp_TxnRef { get; set; }
        public string vnp_OrderInfo { get; set; }
        public string vnp_OrderType { get; set; }
        public string vnp_Amount { get; set; }
        public string vnp_ReturnUrl { get; set; }
        public string vnp_IpAddr { get; set; }
        public string vnp_CreateDate { get; set; }
        public string vnp_BankCode { get; set; }
        public string vnp_SecureHashType { get; set; }
        //public string vnp_ExpireDate { get; set; }

        public VNPayRequestModel SetCommand(string command)
        {
            this.vnp_Command = command;
            return this;
        }

        public VNPayRequestModel SetOrderInfo(string orderId,
            string orderDescription, 
            decimal amount,
            DateTime createDate ,string orderType = "", string bankCode = null)
        {
            this.vnp_TxnRef = orderId;
            this.vnp_OrderInfo = orderDescription;
            this.vnp_CreateDate = createDate.ToString("yyyyMMddHHmmss");
            //this.vnp_ExpireDate = createDate.AddMinutes(15).ToString("yyyyMMddHHmmss");
            this.vnp_Amount = (amount * 100).ToString();
            
            if (!string.IsNullOrEmpty(orderType))
                this.vnp_OrderType = orderType;
            else
                this.vnp_OrderType = "topup";

            if (!string.IsNullOrEmpty(bankCode))
                this.vnp_BankCode = bankCode;

            return this;
        }

        public VNPayRequestModel SetLocale(string locale = "")
        {
            if (!string.IsNullOrEmpty(locale))
                this.vnp_Locale = locale;
            else
                this.vnp_Locale = "vn";
            return this;
        }

        public VNPayRequestModel SetIpAddr(string ipAddress)
        {
            this.vnp_IpAddr = ipAddress;
            return this;
        }
    }
}

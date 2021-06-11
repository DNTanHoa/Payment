using Microsoft.AspNetCore.Mvc;
using Payment.ExternalService;
using Payment.MVC.Extensions;
using Payment.MVC.Models;
using Payment.SharedUltilities.Extensions;
using Payment.SharedUltilities.Global;
using Payment.SharedUltilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IVNPayService vnpayService;

        public PaymentController(IVNPayService vnpayService)
        {
            this.vnpayService = vnpayService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentRedirect(OrderDetailViewModel order)
        {
            order.orderId = DateTime.Now.Ticks.ToString();
            order.amount = 10000;
            order.createdDate = DateTime.Now;

            var requestData = new SortedList<string, string>(new VNPayCompare());

            requestData.AddData("vnp_Version", AppGlobal.VNP_Version);
            requestData.AddData("vnp_Command", "pay");
            requestData.AddData("vnp_TmnCode", AppGlobal.VNP_TMNCode);
            requestData.AddData("vnp_Locale", "vn");

            requestData.AddData("vnp_CurrCode", "VND");
            requestData.AddData("vnp_TxnRef", order.orderId);
            requestData.AddData("vnp_OrderInfo", order.orderDescription);
            requestData.AddData("vnp_OrderType", "topup");
            requestData.AddData("vnp_Amount", (order.amount * 100).ToString());
            requestData.AddData("vnp_ReturnUrl", AppGlobal.VNP_ReturnUrl);
            requestData.AddData("vnp_IpAddr", HttpContext.GetClientIp());
            requestData.AddData("vnp_CreateDate", order.createdDate.ToString("yyyyMMddHHmmss"));

            string paymentRedirectUrl = vnpayService.GetPaymentRedirectUrl(requestData);
            return Redirect(paymentRedirectUrl);
        }
    }
}

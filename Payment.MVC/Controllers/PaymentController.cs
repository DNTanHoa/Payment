using Microsoft.AspNetCore.Mvc;
using Payment.ExternalService;
using Payment.MVC.Extensions;
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

        public IActionResult PaymentRedirect()
        {
            var requestModel = new VNPayRequestModel(true);
            requestModel.SetCommand("pay");
            requestModel.SetOrderInfo(DateTime.Now.Ticks.ToString(), "Noi dung thanh toan:"+ DateTime.Now.Ticks.ToString(), 66000, DateTime.Now);
            requestModel.SetLocale();
            requestModel.SetIpAddr(HttpContext.GetClientIp());

            string paymentRedirectUrl = vnpayService.GetPaymentRedirectUrl(requestModel);
            return Redirect(paymentRedirectUrl);
        }
    }
}

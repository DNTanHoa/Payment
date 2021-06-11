using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.Data.Context;
using Payment.Data.Entities;
using Payment.Data.Extensions;
using Payment.Data.Repositories;
using Payment.ExternalService;
using Payment.MVC.Models;
using Payment.NetCoreExtension;
using Payment.SharedModel.Common;
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
        private readonly IGenericRepository<OrderInfor> genericOrderInforRepository;
        private readonly IGenericRepository<OrderType> genericOrderTypeRepository;
        private readonly IGenericRepository<OrderStatus> genericOrderStatusRepository;
        private readonly IGenericRepository<Bank> genericBankRepository;
        private readonly IGenericRepository<Language> genericLanguageRepository;
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public PaymentController(IVNPayService vnpayService,
            IGenericRepository<OrderInfor> genericOrderInforRepository,
            IGenericRepository<OrderType> genericOrderTypeRepository,
            IGenericRepository<OrderStatus> genericOrderStatusRepository,
            IGenericRepository<Bank> genericBankRepository,
            IGenericRepository<Language> genericLanguageRepository,
            IMapper mapper,
            AppDbContext context)
        {
            this.vnpayService = vnpayService;
            this.genericOrderInforRepository = genericOrderInforRepository;
            this.genericOrderTypeRepository = genericOrderTypeRepository;
            this.genericOrderStatusRepository = genericOrderStatusRepository;
            this.genericBankRepository = genericBankRepository;
            this.genericLanguageRepository = genericLanguageRepository;
            this.mapper = mapper;
            this.context = context;
        }
        public IActionResult Index(OrderDetailViewModel order)
        {
            if(order.banks == null)
            {
                order.banks = genericBankRepository.Get();
            }

            if(order.orderTypes == null)
            {
                order.orderTypes = genericOrderTypeRepository.Get();
            }

            if (order.languages == null)
            {
                order.languages = genericLanguageRepository.Get();
            }

            return View(order);
        }

        public IActionResult PaymentRedirect(OrderDetailViewModel order)
        {
            if (ModelState.IsValid)
            {
                if (!genericOrderTypeRepository.IsExistById(order.orderTypeCode, out OrderType orderType))
                {
                    ModelState.AddModelError("", "Invalid order type");
                    return View();
                }
                var orderInfor = mapper.Map<OrderInfor>(order);

                var oderStatus = genericOrderStatusRepository.GetByID(AppGlobal.DefaultOrderStatusCode);

                orderInfor.SetDefaultValue();
                orderInfor.SetOrderStatus(oderStatus);

                genericOrderInforRepository.Insert(orderInfor);

                int result = context.SaveChanges();

                if(result > 0)
                {
                    var requestData = orderInfor.ToPaymentRequestData(HttpContext.GetClientIp(), order.languageCode);

                    string paymentRedirectUrl = vnpayService.GetPaymentRedirectUrl(requestData);
                    return Redirect(paymentRedirectUrl);
                } 
                else
                {
                    return Json(new CommonResponse().GetCreateFailedResponse("order infor"));
                }
            }
            else
            {
                return View("Index", order);
            }
        }
    }
}

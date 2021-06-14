using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.Data.Context;
using Payment.Data.Entities;
using Payment.Data.Extensions;
using Payment.Data.Repositories;
using Payment.ExternalService;
using Payment.NetCoreExtension;
using Payment.SharedModel.Common;
using Payment.SharedUltilities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IVNPayService vnpayService;
        private readonly IGenericRepository<OrderInfor> genericOrderInforRepository;
        private readonly IGenericRepository<OrderType> genericOrderTypeRepository;
        private readonly IGenericRepository<OrderStatus> genericOrderStatusRepository;
        private readonly IGenericRepository<Bank> genericBankRepository;
        private readonly IGenericRepository<Language> genericLanguageRepository;
        private readonly IGenericRepository<PaymentLog> genericPaymentLogRepository;
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public PaymentController(IVNPayService vnpayService,
            IGenericRepository<OrderInfor> genericOrderInforRepository,
            IGenericRepository<OrderType> genericOrderTypeRepository,
            IGenericRepository<OrderStatus> genericOrderStatusRepository,
            IGenericRepository<Bank> genericBankRepository,
            IGenericRepository<Language> genericLanguageRepository,
            IGenericRepository<PaymentLog> genericPaymentLogRepository,
            IMapper mapper,
            AppDbContext context)
        {
            this.vnpayService = vnpayService;
            this.genericOrderInforRepository = genericOrderInforRepository;
            this.genericOrderTypeRepository = genericOrderTypeRepository;
            this.genericOrderStatusRepository = genericOrderStatusRepository;
            this.genericBankRepository = genericBankRepository;
            this.genericLanguageRepository = genericLanguageRepository;
            this.genericPaymentLogRepository = genericPaymentLogRepository;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public ActionResult<CommonResponse> GetPaymentRedirect(OrderRequestModel order)
        {
            if (ModelState.IsValid)
            {
                if (!genericOrderTypeRepository.IsExistById(order.orderTypeCode, out OrderType orderType))
                {
                    ModelState.AddModelError("", "Invalid order type");
                    return BadRequest();
                }

                var orderInfor = mapper.Map<OrderInfor>(order);
                orderInfor.type = orderType;
                orderInfor.bank = genericBankRepository.GetByID(order.bankCode);

                var oderStatus = genericOrderStatusRepository.GetByID(AppGlobal.DefaultOrderStatusCode);

                orderInfor.SetDefaultValue();
                orderInfor.SetOrderStatus(oderStatus);

                genericOrderInforRepository.Insert(orderInfor);

                int result = context.SaveChanges();

                if (result > 0)
                {
                    var requestData = orderInfor.ToPaymentRequestData(HttpContext.GetClientIp(), order.languageCode);

                    string paymentRedirectUrl = vnpayService.GetPaymentRedirectUrl(requestData);

                    return new CommonResponse().SetData(new { redirectUrl = paymentRedirectUrl });
                }
                else
                {
                    return new CommonResponse().GetCreateFailedResponse("order infor");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

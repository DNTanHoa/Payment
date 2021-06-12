using AutoMapper;
using Payment.Data.Entities;
using Payment.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.MappingProfile
{
    public class PaymentLogMapping : Profile
    {
        public PaymentLogMapping()
        {
            CreateMap<VNPPaymentReturnModel, PaymentLog>()
                .ForMember(x => x.tmnCode, y => y.MapFrom(s => s.vnp_TmnCode))
                .ForMember(x => x.amount, y => y.MapFrom(s => s.vnp_Amount))
                .ForMember(x => x.bankCode, y => y.MapFrom(s => s.vnp_BankCode))
                .ForMember(x => x.bankTranNo, y => y.MapFrom(s => s.vnp_BankTranNo))
                .ForMember(x => x.cardType, y => y.MapFrom(s => s.vnp_CardType))
                .ForMember(x => x.payDate, y => y.MapFrom(s => DateTime.ParseExact(s.vnp_PayDate,"yyyyMMddHHmmss", null)))
                .ForMember(x => x.orderInfor, y => y.MapFrom(s => s.vnp_OrderInfo))
                .ForMember(x => x.transactionNo, y => y.MapFrom(s => s.vnp_TransactionNo))
                .ForMember(x => x.responseCode, y => y.MapFrom(s => s.vnp_ResponseCode))
                .ForMember(x => x.txnRef, y => y.MapFrom(s => s.vnp_TxnRef))
                .ForMember(x => x.secureHash, y => y.MapFrom(s => s.vnp_SecureHash));
        }
    }
}

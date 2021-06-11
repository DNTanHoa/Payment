using AutoMapper;
using Payment.Data.Entities;
using Payment.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.MappingProfile
{
    public class OrderInforMapping : Profile
    {
        public OrderInforMapping()
        {
            CreateMap<OrderDetailViewModel, OrderInfor>();
        }
    }
}

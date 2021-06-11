using AutoMapper;
using Payment.Data.Entities;
using Payment.MVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Mapper.MappingProfile
{
    public class OrderInforMapping : Profile
    {
        public OrderInforMapping()
        {
            CreateMap<OrderDetailViewModel, OrderInfor>();
        }
    }
}

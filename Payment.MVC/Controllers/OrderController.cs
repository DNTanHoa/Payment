using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.Data.Context;
using Payment.Data.Entities;
using Payment.Data.Repositories;
using Payment.SharedModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<OrderInfor> genericOrderInforRepository;
        private readonly AppDbContext context;

        public OrderController(IGenericRepository<OrderInfor> genericOrderInforRepository,
            AppDbContext context)
        {
            this.genericOrderInforRepository = genericOrderInforRepository;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string orderId)
        {
            var model = context.OrderInfor
                .Include(x => x.status)
                .Include(x => x.type)
                .Include(x => x.bank)
                .FirstOrDefault(x => x.orderId == orderId);
            return View(model);
        }

        public IActionResult GetAllPaging(int start, int length)
        {
            var data = genericOrderInforRepository.Get(
                null, null, "type,status");
            return Json(new CommonResponse().SetData(data));
        }

    }
}

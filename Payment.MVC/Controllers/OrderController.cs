using Microsoft.AspNetCore.Mvc;
using Payment.Data.Entities;
using Payment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<OrderInfor> genericOrderInforRepository;

        public OrderController(IGenericRepository<OrderInfor> genericOrderInforRepository)
        {
            this.genericOrderInforRepository = genericOrderInforRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllPaging(int pageNumber, int numberPerPage)
        {
            var data = genericOrderInforRepository.GetPaging(pageNumber, numberPerPage);
            return Json(data);
        }

    }
}

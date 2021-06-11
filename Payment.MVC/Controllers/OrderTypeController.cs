using Microsoft.AspNetCore.Mvc;
using Payment.Data.Entities;
using Payment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class OrderTypeController : Controller
    {
        private readonly IGenericRepository<OrderType> genericOrderTypeRepository;

        public OrderTypeController(IGenericRepository<OrderType> genericOrderTypeRepository)
        {
            this.genericOrderTypeRepository = genericOrderTypeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var data = genericOrderTypeRepository.Get();
            return Json(data);
        }
    }
}

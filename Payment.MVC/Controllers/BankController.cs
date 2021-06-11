using Microsoft.AspNetCore.Mvc;
using Payment.Data.Entities;
using Payment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class BankController : Controller
    {
        private readonly IGenericRepository<Bank> genericBankRepository;

        public BankController(IGenericRepository<Bank> genericBankRepository)
        {
            this.genericBankRepository = genericBankRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var data = genericBankRepository.Get();
            return Json(data);
        }
    }
}

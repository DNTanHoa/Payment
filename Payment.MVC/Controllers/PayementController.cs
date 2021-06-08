using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Controllers
{
    public class PayementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

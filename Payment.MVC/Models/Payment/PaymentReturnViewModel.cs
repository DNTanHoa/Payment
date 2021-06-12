using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Models
{
    public class PaymentReturnViewModel
    {
        public string message { get; set; }
        public bool isSuccess { get; set; }
    }
}

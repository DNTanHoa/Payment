using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string code { get; set; }
        public string name { get; set; }

    }
}

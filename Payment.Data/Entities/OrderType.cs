using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Entities
{
    public class OrderType : BaseEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string shortName { get; set; }
    }
}

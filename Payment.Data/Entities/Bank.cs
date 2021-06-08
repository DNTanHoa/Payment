using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Entities
{
    public class Bank : BaseEntity
    {
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string bankShortName { get; set; }
        public string bankLogo { get; set; }
    }
}

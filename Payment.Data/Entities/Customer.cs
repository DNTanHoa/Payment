using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Entities
{
    public class Customer
    {
        public string code { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Gender gender { get; set; }
        public Province province { get; set; }
        public District district { get; set; }
        public Ward ward { get; set; }
        public string address { get; set; }
        public string fullAddress { get; set; }
        public string identityNumber { get; set; }
        public string identityPlace { get; set; }
        public DateTime identityDate { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public string taxCode { get; set; }
        public string note { get; set; }
    }
}

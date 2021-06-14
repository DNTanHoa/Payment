using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Entities
{
    public class MasterCategory : BaseEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string value { get; set; }
        public string description { get; set; }
    }
}

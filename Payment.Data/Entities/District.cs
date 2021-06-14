using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Entities
{
    public class District
    {
        public string code { get; set; }
        public string name { get; set; }
        public Province province { get; set; }
    }
}

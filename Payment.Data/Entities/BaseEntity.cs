using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Entities
{
    public class BaseEntity
    {
        public User createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public User lastUpdatedBy { get; set; }
        public DateTime lastUpdatedAt { get; set; }
    }
}

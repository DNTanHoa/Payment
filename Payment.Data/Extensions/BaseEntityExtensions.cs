using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Extensions
{
    public static class BaseEntityExtensions
    {
        public static void SetAuditValue(this BaseEntity baseEntity, User user, bool isNewObject = false)
        {
            if (isNewObject)
            {
                baseEntity.createdBy = user;
            }
            baseEntity.lastUpdatedBy = user;
        }
    }
}

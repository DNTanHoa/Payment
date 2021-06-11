using Payment.Data.Entities;
using Payment.SharedUltilities.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Extensions
{
    public static class OrderInforExtensions
    {
        public static void SetDefaultValue(this OrderInfor order)
        {
            if (string.IsNullOrEmpty(order.orderId))
            {
                order.orderId = AppGlobal.DefaultStringCode;
            }
        }
    }
}

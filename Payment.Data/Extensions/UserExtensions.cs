using Payment.Data.Entities;
using Payment.SharedUltilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Extensions
{
    public static class UserExtensions
    {
        public static void SetPassword(this User user)
        {
            if (string.IsNullOrEmpty(user.hashkey))
            {
                user.hashkey = Guid.NewGuid().ToString();
            }

            user.password = SecurityHelper.Encrypt(user.hashkey, user.password);
        }
    }
}

using FluentValidation;
using Payment.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.MVC.Validation
{
    public class OrderInforValidation : AbstractValidator<OrderDetailViewModel>
    {
        public OrderInforValidation()
        {
            RuleFor(x => x.amount).GreaterThan(0).WithMessage("Số tiền phải lớn hơn 0");
        }
    }
}

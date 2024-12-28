using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.AppServices.Validators
{
    public class ProductValidator:AbstractValidator<ProductModel>
    {
        public ProductValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}

using FluentValidation;
using TestWorkTask.Models;

namespace WorkTask.AppServices.Validators
{
    public class OrderValidator: AbstractValidator<OrderModel>
    {
        public OrderValidator() 
        {
            RuleFor(x => x.Sum).GreaterThan(0);
            RuleFor(x => x.CreatAt).NotEmpty().NotNull();
            RuleFor(x => x.User).SetValidator(new UserValidator());
            RuleForEach(x=> x.Products).SetValidator(new ProductValidator());
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.AppServices.Validators
{
    public class UserValidator: AbstractValidator<UserModel>
    {
        public UserValidator() 
        {
            RuleFor(x => x.FullName).MaximumLength(60);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}

using FluentValidation;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı Adı Boş olamaz..!");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı Boş olamaz..!");
            RuleFor(p => p.EmailAddress).NotEmpty().WithMessage("E-mail adresi Olamaz..!");
        }
    }
}

using FluentValidation;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.ValidationRules.FluentValidation
{
    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Pozisyon Adı Boş olamaz..!");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Pozisyon Boş Olamaz..!");
        }
    }
}

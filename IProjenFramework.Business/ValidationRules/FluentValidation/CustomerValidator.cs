using FluentValidation;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.DisplayName).NotEmpty().WithMessage("Görünecek isim boş olmaz..!");
            RuleFor(p => p.CommercialTitle).NotEmpty().WithMessage("Ticari Ünvan boş olamaz..!");
            RuleFor(p => p.TaxOffice).NotEmpty().WithMessage("Vergi dairesi boş olamaz..!");
            RuleFor(p => p.TaxNumber).MinimumLength(10).MaximumLength(10)
                .When(x => x.TaxNumber != null).WithMessage("Vergi numarası 10 karakter olmalıdır..!");
            RuleFor(p => p.Identifier).MinimumLength(11).MaximumLength(11)
                .When(x => x.Identifier != null).WithMessage("Vergi numarası 11 karakter olmalıdır..!");
            RuleFor(p => p.EmailAddress).EmailAddress().WithMessage("Email adresi geçersiz..!");
            RuleFor(p => p.TelephoneNumber).MaximumLength(10).WithMessage("Telefon numarası en fazla 20 karakter olmalıdır..!");
            RuleFor(p => p.FaxNumber).MaximumLength(10).WithMessage("Faks numarası en fazla 20 karakter olmalıdır..!");
        }
    }
}

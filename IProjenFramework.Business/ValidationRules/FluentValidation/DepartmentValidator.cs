using FluentValidation;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.ValidationRules.FluentValidation
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Departman Adı Boş olamaz..!");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama Boş Olamaz..!");
            //RuleFor(p => p.CreateDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Tarih bugünden küçük olamaz..!!");
        }
        
    }
}

using FluentValidation;
using IProjenFramework.Business.ValidationRules.FluentValidation;
using IProjenFramework.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Department>>().To<DepartmentValidator>().InSingletonScope();
            Bind<IValidator<Position>>().To<PositionValidator>().InSingletonScope();
            Bind<IValidator<User>>().To<UserValidator>().InSingletonScope();
            Bind<IValidator<Customer>>().To<CustomerValidator>().InSingletonScope();
        }
    }
}

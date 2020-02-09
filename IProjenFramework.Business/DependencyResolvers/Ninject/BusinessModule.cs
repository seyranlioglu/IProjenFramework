using IProjenFramework.Business.Abstract;
using IProjenFramework.Business.Concrete;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<UserDal>().InSingletonScope();

            Bind<IUserPositionService>().To<UserPositionManager>().InSingletonScope();
            Bind<IUserPositionDal>().To<UserPositionDal>().InSingletonScope();

            Bind<IFormService>().To<FormManager>().InSingletonScope();
            Bind<IFormDal>().To<FormDal>().InSingletonScope();

            Bind<IFormUserRightsService>().To<FormUserRightsManager>().InSingletonScope();
            Bind<IFormUserRightsDal>().To<FormUserRightSetDal>().InSingletonScope();

            Bind<IDepartmentService>().To<DepartmentManager>().InSingletonScope();
            Bind<IDepartmentDal>().To<DepartmentDal>().InSingletonScope();

            Bind<IPositionService>().To<PositionManager>().InSingletonScope();
            Bind<IPositionDal>().To<PositionDal>().InSingletonScope();

            Bind<IDesignGroupService>().To<DesignGroupManager>().InSingletonScope();
            Bind<IDesignGroupDal>().To<DesignGroupDal>().InSingletonScope();

            Bind<IDesignGroupDetailService>().To<DesignGroupDetailManager>().InSingletonScope();
            Bind<IDesignGroupDetailDal>().To<DesignGroupDetailDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<CustomerDal>().InSingletonScope();
        }
    }
}

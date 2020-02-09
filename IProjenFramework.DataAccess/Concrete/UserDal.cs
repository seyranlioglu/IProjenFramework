using IProjenFramework.Core.DataAccess.EntityFramework;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.DataAccess.Concrete.Context;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, IProjenFrameworkContext>, IUserDal
    {
        
    }
}

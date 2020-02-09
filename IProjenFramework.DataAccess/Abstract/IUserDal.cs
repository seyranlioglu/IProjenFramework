using IProjenFramework.Core.DataAccess;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}

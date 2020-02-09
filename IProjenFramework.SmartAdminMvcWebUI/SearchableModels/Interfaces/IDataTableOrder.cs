using IProjenFramework.MvcWebUI.App_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.MvcWebUI.SearchableModels.Interfaces
{
    public interface IDataTableOrder<T> where T : class
    {
        Func<IQueryable<T>, IOrderedQueryable<T>> CreateOrderExpression(DataTableAjaxPostModel model);
    }
}

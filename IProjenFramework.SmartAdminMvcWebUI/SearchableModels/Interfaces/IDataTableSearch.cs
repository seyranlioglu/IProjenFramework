using IProjenFramework.MvcWebUI.App_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.MvcWebUI.SearchableModels.Interfaces
{
    public interface IDataTableSearch<T> where T : class
    {
        Expression<Func<T, bool>> CreateSearchExpression(DataTableAjaxPostModel model);
    }
}

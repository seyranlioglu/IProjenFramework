using IProjenFramework.Core.ExpressionBuilder.Orders;
using IProjenFramework.MvcWebUI.App_Helper;
using IProjenFramework.MvcWebUI.SearchableModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.SearchableModels
{
    public class DataTableOrder<T> : IDataTableOrder<T> where T : class
    {
        public Func<IQueryable<T>, IOrderedQueryable<T>> CreateOrderExpression(DataTableAjaxPostModel model)
        {
            var order = new OrderHelper<T>();
            string sortBy = "Id";
            bool sortDir = false;

            if (model.order != null)
            {
                sortBy = model.columns[model.order[0].column].name;
                sortDir = model.order[0].dir.ToLower() == "desc";
            }
            return order.OrderByFunc(sortBy, sortDir);
        }
    }
}
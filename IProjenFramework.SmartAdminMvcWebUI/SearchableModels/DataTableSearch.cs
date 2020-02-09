using IProjenFramework.Core.ExpressionBuilder.Common;
using IProjenFramework.Core.ExpressionBuilder.Generics;
using IProjenFramework.Core.ExpressionBuilder.Helpers;
using IProjenFramework.Core.ExpressionBuilder.Operations;
using IProjenFramework.MvcWebUI.App_Helper;
using IProjenFramework.MvcWebUI.SearchableModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IProjenFramework.MvcWebUI.SearchableModels
{
    public class DataTableSearch<T> : IDataTableSearch<T> where T : class
    {
        public Expression<Func<T, bool>> CreateSearchExpression(DataTableAjaxPostModel model)
        {
            Expression<Func<T, bool>> predicate = null;

            var searchBy = (model.search != null) ? model.search.value : null;

            if (searchBy != null)
            {
                predicate = SearchAllColumnsQuery(searchBy, model.columns);
            }
            if (model.columns.Count > 0)
            {
                if (model.columns.Where(k => k.search.value != null).Count() > 0)
                {
                    predicate = SearchSingleColumnQuery(model.columns);
                }
            }
            return predicate;
        }

        /// <summary>
        ///  Kolon Kolon Arama İşlemi
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        private Expression<Func<T, bool>> SearchSingleColumnQuery(List<Column> columns)
        {
            var filter = new Filter<T>();
            foreach (Column col in columns)
            {
                if (col.search.value != null) {
                    ExpressionOperationHelper operation = ExpressionOperation.GetExpressionOperation(
                        TypeofReferences<T>.GetType(col.name), col.search.value, null);
                    filter.By(
                        col.name,
                        operation.VOperation,
                        operation.Value,
                        Connector.And
                   );
                }
            }
            return filter;
        }
        /// <summary>
        /// Tün kolonlarda arama (sadece data tipi string olanlar)
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private Expression<Func<T, bool>> SearchAllColumnsQuery(string searchBy, List<Column> columns)
        {
            var filter = new Filter<T>();
            var searchTerms = searchBy.Split('|').ToList().ConvertAll(x => x.ToLower());
            Dictionary<string, string> keys = TypeofReferences<T>.GetAllTypeofReference();
            foreach (Column col in columns.Where(k => keys.Select(m => m.Key).Contains(k.name)))
            {
                foreach (var srch in searchTerms)
                {
                    filter.By(col.name, Operation.Contains, srch, Connector.Or);
                }
            }
            return filter;
        }
    }
}
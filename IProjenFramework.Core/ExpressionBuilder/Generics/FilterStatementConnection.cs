﻿
using IProjenFramework.Core.ExpressionBuilder.Common;
using IProjenFramework.Core.ExpressionBuilder.Interfaces;

namespace IProjenFramework.Core.ExpressionBuilder.Generics
{
    /// <summary>
    /// Connects to FilterStatement together.
    /// </summary>
	public class FilterStatementConnection : IFilterStatementConnection
    {
        private readonly IFilter _filter;
        private readonly IFilterStatement _statement;

        public FilterStatementConnection()
        {
        }

        internal FilterStatementConnection(IFilter filter, IFilterStatement statement)
        {
            _filter = filter;
            _statement = statement;
        }

        /// <summary>
		/// Defines that the last filter statement will connect to the next one using the 'AND' logical operator.
		/// </summary>
		public IFilter And
        {
            get
            {
                _statement.Connector = Connector.And;
                return _filter;
            }
        }

        /// <summary>
        /// Defines that the last filter statement will connect to the next one using the 'OR' logical operator.
        /// </summary>
		public IFilter Or
        {
            get
            {
                _statement.Connector = Connector.Or;
                return _filter;
            }
        }
    }
}
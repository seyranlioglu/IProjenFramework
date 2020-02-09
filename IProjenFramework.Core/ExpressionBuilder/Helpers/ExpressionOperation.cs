using IProjenFramework.Core.ExpressionBuilder.Interfaces;
using IProjenFramework.Core.ExpressionBuilder.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.Core.ExpressionBuilder.Helpers
{
    public class ExpressionOperationHelper
    {
        public object Value { get; set; }
        public object Value2 { get; set; }
        public IOperation VOperation { get; set; }
        
    }

    public class ExpressionOperation
    {
        public static ExpressionOperationHelper GetExpressionOperation(Type type, object value, object value2 = null)
        {
            IExpressionOperationHelper hp = Activator.CreateInstance(
                    Type.GetType("IProjenFramework.Core.ExpressionBuilder.Helpers." + type.Name)) 
                    as IExpressionOperationHelper;
            return hp.SetHelper(type, value, value2);
        }
    }

    public interface IExpressionOperationHelper
    {
        ExpressionOperationHelper SetHelper(Type type, object value, object value2 = null);
    }
    public class String : IExpressionOperationHelper
    {
        public ExpressionOperationHelper SetHelper(Type type, object value, object value2 = null)
        {
            return new ExpressionOperationHelper()
            {
                Value = value,
                VOperation = Operation.Contains
            };
        }
    }

    public class Int32 : IExpressionOperationHelper
    {
        public ExpressionOperationHelper SetHelper(Type type, object value, object value2 = null)
        {
            return new ExpressionOperationHelper()
            {
                Value = Convert.ToInt32(value),
                Value2 = value2 ?? Convert.ToInt32(value2),
                VOperation = Operation.EqualTo
            };
        }
    }

    public class DateTime : IExpressionOperationHelper
    {
        public ExpressionOperationHelper SetHelper(Type type, object value, object value2 = null)
        {
            return new ExpressionOperationHelper()
            {
                Value = Convert.ToDateTime(value),
                Value2 = value2 ?? Convert.ToDateTime(value2),
                VOperation = Operation.EqualTo
            };
        }
    }


}
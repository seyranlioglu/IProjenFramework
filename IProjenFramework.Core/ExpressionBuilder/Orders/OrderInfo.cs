using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Core.ExpressionBuilder.Orders
{
    public class OrderInfo
    {
        public OrderType OrderType { get; set; }
        public string Property { get; set; }
    }
    public enum OrderType
    {
        None = 0,
        ASC = 1,
        DESC = 2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.ComplexType
{
    public class UserPositionView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public string UserName { get; set; }
        public string PositionName { get; set; }
    }
}

using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class UserPosition : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}

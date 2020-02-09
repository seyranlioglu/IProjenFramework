using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class DesignGroupDetail : IEntity
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int DesignGroupId { get; set; }
        [JsonIgnore]
        public virtual Form Form { get; set; }
        [JsonIgnore]
        public virtual DesignGroup DesignGroup { get; set; }
    }
}

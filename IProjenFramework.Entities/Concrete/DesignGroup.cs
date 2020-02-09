using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class DesignGroup : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public Nullable<int> MasterGroupId { get; set; }
        [JsonIgnore]
        public virtual DesignGroup MasterGroup { get; set; }
        [JsonIgnore]
        public virtual List<DesignGroupDetail> DesignGroupDetails { get; set; }
    }
}

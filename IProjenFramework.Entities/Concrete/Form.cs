using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class Form : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        [JsonIgnore]
        public virtual List<DesignGroupDetail> DesignGroupDetails { get; set; }
        [JsonIgnore]
        public virtual List<FormUserRightSet> FormUserRightSets { get; set; }
        [JsonIgnore]
        public List<FormProperty> FormProperties { get; set; }
    }
}

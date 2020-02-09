using IProjenFramework.Core.Entities;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace IProjenFramework.Entities.Concrete
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual List<Position> Positions { get; set; }
    }
}

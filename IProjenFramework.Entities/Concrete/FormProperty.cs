using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class FormProperty : IEntity
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string ImageIcon { get; set; }
        [JsonIgnore]
        public virtual Form Form { get; set; }
    }
}

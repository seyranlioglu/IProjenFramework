using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class FormUserRightSet : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserTypes UserType { get; set; }
        public int FormId { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }
        [JsonIgnore]
        public virtual Form Form { get; set; }

        public enum UserTypes
        {
            User = 1,
            Position = 2,
            Department = 3
        }
    }
}

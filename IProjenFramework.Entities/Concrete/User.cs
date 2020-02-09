using IProjenFramework.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Locked { get; set; }
        public bool IsAdminUser { get; set; }
        [JsonIgnore]
        public virtual List<UserPosition> UserPositions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.ComplexType
{
    public class FormUserRightSetView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }
    }
}

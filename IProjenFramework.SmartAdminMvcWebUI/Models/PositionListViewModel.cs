using IProjenFramework.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class PositionListViewModel
    {
        public List<PositionView> Position { get; set; }
        public int FormId { get; set; }
    }
}
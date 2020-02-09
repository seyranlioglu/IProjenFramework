using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class District
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DistrictCode { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}

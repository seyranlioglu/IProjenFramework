using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
        public string CityCode { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<District> Districts { get; set; }
    }
}

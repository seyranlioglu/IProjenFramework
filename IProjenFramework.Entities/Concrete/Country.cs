using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }       
        public string CountryCode { get; set; }
        [MaxLength(3)]
        public string ISOCode { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }
    }
}

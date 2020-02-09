using IProjenFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Entities.Concrete
{
    public class Customer : Base,IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string DisplayName { get; set; }
        [Required]
        public string CommercialTitle { get; set; }
        [Required]
        public string TaxOffice { get; set; }
        [MaxLength(10)]
        public string TaxNumber { get; set; }
        [MaxLength(11)]
        public string Identifier { get; set; }
        [MaxLength(20)]
        public string TelephoneNumber { get; set; }
        [MaxLength(20)]
        public string FaxNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [MaxLength(50)]
        public string WebAddress { get; set; }

    }
}

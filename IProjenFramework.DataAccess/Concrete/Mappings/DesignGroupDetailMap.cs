using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete.Mappings
{
    public class DesignGroupDetailMap : EntityTypeConfiguration<DesignGroupDetail>
    {
        public DesignGroupDetailMap()
        {
            ToTable(@"DesignGroupDetails", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.FormId).HasColumnName("FormId");
            Property(x => x.DesignGroupId).HasColumnName("DesignGroupId");
        }
    }
}

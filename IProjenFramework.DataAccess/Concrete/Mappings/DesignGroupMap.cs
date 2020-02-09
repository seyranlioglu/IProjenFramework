using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete.Mappings
{
    public class DesignGroupMap : EntityTypeConfiguration<DesignGroup>
    {
        public DesignGroupMap()
        {
            ToTable(@"DesignGroups", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.Locked).HasColumnName("Locked");
            Property(x => x.MasterGroupId).HasColumnName("MasterGroupId");
            HasOptional(x => x.MasterGroup).WithMany().HasForeignKey(x => x.MasterGroupId);
        }
    }
}

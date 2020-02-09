using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete.Mappings
{
    public class FormUserRightSetMap : EntityTypeConfiguration<FormUserRightSet>
    {
        public FormUserRightSetMap()
        {
            ToTable(@"FormUserRightSets", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.UserId).HasColumnName("UserId");
            Property(x => x.UserType).HasColumnName("UserType");
            Property(x => x.FormId).HasColumnName("FormId");
            Property(x => x.ViewRight).HasColumnName("ViewRight");
            Property(x => x.InsertRight).HasColumnName("InsertRight");
            Property(x => x.UpdateRight).HasColumnName("UpdateRight");
            Property(x => x.DeleteRight).HasColumnName("DeleteRight");
        }
    }
}

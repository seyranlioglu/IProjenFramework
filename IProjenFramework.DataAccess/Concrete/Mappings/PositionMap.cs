using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete.Mappings
{
    public class PositionMap : EntityTypeConfiguration<Position>
    {
        public PositionMap()
        {
            ToTable(@"Positions", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.DepartmentId).HasColumnName("DepartmentId");

            //HasOptional(x => x.Department)
            //    .WithMany()
            //    .HasForeignKey(x => x.DepartmentId)
            //    .WillCascadeOnDelete();
        }
    }
}

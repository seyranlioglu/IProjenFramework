using IProjenFramework.Core.Utilities.Cryptology;
using IProjenFramework.DataAccess.Concrete.Mappings;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete.Context
{
    public class IProjenFrameworkContext : DbContext
    {
        public IProjenFrameworkContext() : base(Cryptology.Decrypt(ConfigurationManager.ConnectionStrings["IProjenFrameworkContext"].ConnectionString))
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IProjenFrameworkContext, IProjenFramework.DataAccess.Migrations.Configuration>(true));
            this.Database.CommandTimeout = 600;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DesignGroup> DesignGroups { get; set; }
        public DbSet<DesignGroupDetail> DesignGroupDetails { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormProperty> FormProperties { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<FormUserRightSet> FormUserRightSets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new DesignGroupMap());
            modelBuilder.Configurations.Add(new DesignGroupDetailMap());
            modelBuilder.Configurations.Add(new FormMap());
            modelBuilder.Configurations.Add(new PositionMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserPositionMap());
            modelBuilder.Configurations.Add(new FormUserRightSetMap());
        }
    }
}

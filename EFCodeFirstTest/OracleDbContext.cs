using EFCodeFirstTest.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{
    public class OracleDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Department> Departments { set; get; }

        public virtual DbSet<T_PMI_APP> T_PMI_APP { get; set; }

        public virtual DbSet<Person> Persons { set; get; }

        public virtual DbSet<PerCompany> PerCompany { set; get; }

        public virtual DbSet<Company> Company { set; get; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new APPMap());
            modelBuilder.Entity<Employee>().HasOptional(x => x.Department)
                .WithMany(t => t.Employees);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.HasDefaultSchema("TYUM_FS");
        }
    }
}

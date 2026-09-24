using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(@"Roles", @"dbo");
            HasKey(r => r.Id);
            Property(r => r.Name).HasColumnName("Name");
        }
    }
}

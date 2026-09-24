using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap:EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable(@"UserRole", @"dbo");
            HasKey(ur => ur.Id);
            Property(ur => ur.UserId).HasColumnName("UserId");
            Property(ur => ur.RoleId).HasColumnName("RoleId");
        }
    }
}

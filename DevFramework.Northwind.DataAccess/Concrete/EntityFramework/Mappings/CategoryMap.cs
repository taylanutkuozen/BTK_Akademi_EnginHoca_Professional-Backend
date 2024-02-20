using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap :EntityTypeConfiguration<Category>//19.Adım
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(c => c.CategoryID);
            Property(c => c.CategoryName).HasColumnName("CategoryName");
        }
    }
}
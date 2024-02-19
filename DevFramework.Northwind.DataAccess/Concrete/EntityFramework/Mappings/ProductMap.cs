using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
13.Sırada
*/
namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap:EntityTypeConfiguration<Product>//Map işlemi gerçekleşmesi için kullanılır.
    {
        public ProductMap()
        {
            ToTable(@"Products", "dbo");
            HasKey(x => x.ProductId);
            Property(x=>x.ProductId).HasColumnName("ProductID");//kolonları isimlendirildi.
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
        }
    }
}
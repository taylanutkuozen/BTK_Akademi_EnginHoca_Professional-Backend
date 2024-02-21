using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
16.Adım
NHibarnate'i SqlServer'a göre map işlemi için kullanacağız.
*/
namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product> //FluentNHibernate içerisinden geliyor.
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductId).Column("ProductID");//.Column("column_name")=tabloda column_name'i aramak için bu komut kullanılır.
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");
        }
    }
}
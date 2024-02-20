using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
20.Adımda NHibernate için Category entitysini gerçekleştireceğiz. Entity ve interface hazır olduğu için direk map'lemeden başlıyoruz. Sonrasında NHibernate için bir NhCategoryDal ekliyoruz.
*/
namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(c => c.CategoryID).Column("CategoryID");
            Map(c => c.CategoryName).Column("CategoryName");
        }
    }
}
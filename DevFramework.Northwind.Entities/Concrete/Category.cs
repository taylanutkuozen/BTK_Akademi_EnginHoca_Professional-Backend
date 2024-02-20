using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
19.Adımda=Tekrar etmek için bir entity tanımlıyoruz. DataAcces'e gider. Abstract ICategoryDal yapar ve IEntityRepository'den implemente eder ve Category ile çalışacağını belirtir.ICategoryDal tanımlanırken bir veritabanı nesnesi IEntity implemente edilmesi gereklidir. Hangi teknolojiyi kullanıyorsak(EF örneğin) ilk aşama mapping yapacaksak bir DataAccess Concrete gidiyoruz. Sonrasında ilgili context'te entity tanımlıyoruz. Son olarak data access concrete içerisinde EFCategoryDal tanımlıyoruz.
*/
namespace DevFramework.Northwind.Entities.Concrete
{
    public class Category :IEntity
    {
        public virtual int CategoryID { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
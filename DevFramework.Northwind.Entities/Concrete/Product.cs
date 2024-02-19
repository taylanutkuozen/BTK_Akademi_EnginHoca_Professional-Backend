using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;
/*
18.Adımda NHibernate testini yaptık. Testi yaparken Entity için virtual yapıyoruz propertylerimizi. 
*/
namespace DevFramework.Northwind.Entities.Concrete
{
    public class Product:IEntity /*Veritabanı nesneleri IEntityden implemente edilmelidir. IEntityRepository' IEntity'den implement edilmelidir. yoksa kullanılamaz.*/
    {
        public virtual int ProductId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual decimal UnitPrice { get; set; }
    }
}
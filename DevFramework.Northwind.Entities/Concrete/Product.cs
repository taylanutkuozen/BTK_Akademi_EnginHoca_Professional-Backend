using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;
/*
10.Sırada-Nesneler oluşturduk. 
*/
namespace DevFramework.Northwind.Entities.Concrete
{
    public class Product:IEntity /*Veritabanı nesneleri IEntityden implemente edilmelidir. IEntityRepository' IEntity'den implement edilmelidir. yoksa kullanılamaz.*/
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
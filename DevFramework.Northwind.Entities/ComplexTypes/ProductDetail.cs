using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
21.Adım=ilk olarak bir entity oluşturduk. Sonrasında temel nesne Product olduğu için IProductDal'a gidiyoruz. bu işlemden sonra IProductDal implementasyonlarının olduğu class'larda gerekli düzenlemeler yapılmalıdır.
*/
namespace DevFramework.Northwind.Entities.ComplexTypes
{
    public class ProductDetail
    {
        public virtual int ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
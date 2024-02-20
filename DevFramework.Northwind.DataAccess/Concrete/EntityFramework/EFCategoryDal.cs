using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 19.Adım
*/
namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {

    }
}
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3.Sırada
namespace DevFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class,IEntity, new()
        /*List'ler ile çalıştığımız zaman context açıp kaparız. ToList() görüldüğü zaman db ile ilgili olan bütün context sonlanmış oluyor.*/
        /*IQuaryable sorguların Business tarafında context açılıp kapanmadan çalışabilmesi için bu repository eklendi.*/
    {
        IQueryable<T> Table { get; } //IQuaryable sadece Select operasyonları için yazılır. Readonly. Bir context attach olunacak. O context'e bağlı çalışmalar yapılacak.
    }
}
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//1.Sırada
namespace DevFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new() /*Constraint uyguladık Generic yapıya*/
    {
        List<T> GetList(Expression<Func<T,bool>> filter=null);//Datanın tümü veya where koşulu ile data gelmesi için Expression faydalandık. filter=null koşulu datanın tümü gelecektir.
        T Get(Expression<Func<T,bool>> filter); //Tek bir nesne getirebilmek için yazıldı.
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
} 
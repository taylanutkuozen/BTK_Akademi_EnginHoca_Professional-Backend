using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 5.Sırada 
 context kapatmadan birden fazla işlem yapıp, örnek olarak iki sorgu çekip arada business logic işler yapmak için kullanılacaktır.
 OData işlemleri için IQuaryable kullanılabilmektedir.
 */
namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;/*IQuaryable daki Table property'si bir DbSet karşılık gelmektedir.*/
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }/*Dependency Injection=Business katmanının herhangi bir projeye bağlı olması engellenecektir*/
        public IQueryable<T> Table => this.Entities;
        protected virtual IDbSet<T> Entities /*Başka class'lar kullanamasın diye protected yapıldı. virtual=lazy loading için yazıldı*/
        {
            get 
            { 
                if(_entities==null)/*ikinci çağırdığında yine aynısı kullanılmalı*/
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
            //get {return _entities ?? (_entities=_context.Set<T>()); }
        }
    }
}
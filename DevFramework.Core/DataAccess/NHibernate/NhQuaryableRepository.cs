using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 8.Sırada
 */
namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQuaryableRepository<T>:IQueryableRepository<T> where T : class,IEntity,new()
    {
        private NHibernateHelper _nHibernateHelper;
        public NhQuaryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
        private IQueryable<T> _entities;
        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        public virtual IQueryable<T> Entities
        {
            get 
            { 
                if(_entities == null)
                {
                  _entities=_nHibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
            /*get {return _entities ?? (_entities=_nHibernateHelper.OpenSession().Query<T>());}*/
        }
    }
}
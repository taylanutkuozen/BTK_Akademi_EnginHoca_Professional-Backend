using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 6.Sırada
 NHibernate nugetPackage kısmından ekliyoruz.
 */
namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;//Veritabanına göre bir konfigürasyon gönderecektir.
        /*NHibernate Session=EntityFramework Context
         Factory Design Pattern'inden bahsediyor*/
        public virtual ISessionFactory SessionFactory { get { return _sessionFactory ??(_sessionFactory=InitializeFactory()); } }
        /*Virtual ya lazy loading veya navigation property bir nesneden yola çıkarak o nesnenin ilişki durumlarını incelemek*/
        protected abstract ISessionFactory InitializeFactory();/*implement eden db ye göre hazırlanacaktır(örneğin oracle,mysql)*/
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
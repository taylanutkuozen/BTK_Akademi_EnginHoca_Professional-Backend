using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//4.Sırada
namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new() 
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context=new TContext()) /*Garbage Collector scope bitince oluşturulan nesneyi temizlemesi için using'ten faydalandık.*/
            {
                var addedEntity=context.Entry(entity);/*hangi nesneye abone olunacak.Entry(nesneyi_parametre_olarak_ver)*/
                addedEntity.State = EntityState.Added;/*Durumunu eklenecek data olarak bildir.*/
                context.SaveChanges();
                return entity;
            }
        }
        public void Delete(TEntity entity)
        {
            using (var context=new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().ToList()
                    :context.Set<TEntity>().Where(filter).ToList();
                /*İlgili TEntity ye abone olmak için=context.Set<TEntity>()*/
            }
        }
        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
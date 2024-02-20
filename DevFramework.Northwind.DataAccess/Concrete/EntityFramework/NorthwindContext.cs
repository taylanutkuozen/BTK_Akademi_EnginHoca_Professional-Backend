using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
12.sırada
CodeFirst teknolojisi. Hazır bir db den reverse technology olacaktır.
*/
namespace DevFramework.Northwind.Entities.Concrete
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null); //Migration'ı kapattık. Veritabanı hazır. Yeniden oluşturmaya çalışma.
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }//19.Adım
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());//Map işleminin gerçekleşmesi için yapılması gereken komutlar.
        }
    }
}
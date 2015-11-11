using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Storeges
{
    public class CRUD
    {
        public static void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            using (var db = new LaborExchangeContext())
            {
                //db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public static IQueryable<TEntity> Select<TEntity>(DbContext db) where TEntity : class
        {
            //var db = new LaborExchangeContext();

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            return db.Set<TEntity>();
        }

        public static void Update<TEntity>(TEntity entity, DbContext db) where TEntity : class
        {
            // Настройки контекста
            //db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            // Настройки контекста
            using (var db = new LaborExchangeContext())
            {
                //db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}

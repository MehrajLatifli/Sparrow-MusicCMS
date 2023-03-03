using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicCMS_Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicCMS_Core.Data_Access.EntityFrameworkCore
{
    public class EF_EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {

        //static void Validate(ChangeTracker changeTracker)
        //{
        //    var entities = changeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).Select(e => e.Entity);

        //    foreach (var entity in entities)
        //    {
        //        var validationContext = new ValidationContext(entity);
        //        Validator.ValidateObject(entity, validationContext, validateAllProperties: true);

        //        Debug.WriteLine(entity);

        //    }
        //}

        static void Validate2(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Debug.WriteLine($@"Entity: {entry.Entity.GetType().Name},
        
                                     State: {entry.State.ToString()}
                ");
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                //Validate(context.ChangeTracker);
                Validate2(context.ChangeTracker.Entries());

                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    //Validate(context.ChangeTracker);
                    Validate2(context.ChangeTracker.Entries());

                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                // move on
            }
            catch (DbUpdateException ex)
            {
                // get latest version of record for display
            }


        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                Validate2(context.ChangeTracker.Entries());

                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                try
                {
                //Validate(context.ChangeTracker);
                Validate2(context.ChangeTracker.Entries());

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges(true);

                }
                //catch (DbEntityValidationException vex)
                //{
                //    var exception = HandleDbEntityValidationException(vex);
                //    throw exception;
                //}
                catch (DbUpdateConcurrencyException dbu)
                {
                    var exception = HandleDbUpdateException(dbu);
                    Debug.WriteLine(exception.Message.ToString());

                    throw exception;

                }
            }
        }

        


        private Exception HandleDbUpdateException(DbUpdateConcurrencyException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem.", result.Entity.GetType().FullName);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }
    }

}

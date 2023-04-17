using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DishoutOLO.Repo
{
    public class Repository<T> : IRepository<T> where T  : BaseEntity
    {
        private readonly DishoutOLOContext context;
        private DbSet<T> entities;

        public Repository(DishoutOLOContext context)
            {
            this.context = context;
            entities = context.Set<T>();
        }

        public IList<T> GetAll()

        {
            return entities.ToList();
        }


        public IQueryable<T> GetAllAsQuerable()
        {
            return entities.AsQueryable();
        }

        public void Insert(T entity)
        {
       


             try
            {
                context.Database.BeginTransaction();
                entities.Add(entity);
                context.SaveChanges();
                context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
            }
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
         
        }

        public int InsertAndGetId(T entity)
        {

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                context.Database.BeginTransaction();

                entities.Add(entity);
                context.SaveChanges();
                context.Database.CommitTransaction();

                return entity.Id;
            }
            catch(Exception ex)
            {
                context.Database.RollbackTransaction();
            }
            return entity.Id;
        }
        public void Update(T entity)
        {

            try
            {
                var local = context.Set<T>()
             .Local
             .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

                if (local != null)
                {
                    context.Entry(local).State = EntityState.Detached;
                }
                context.Database.BeginTransaction();


                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();
            }
          

        }
        public void Delete(T entity)
        {

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                context.Database.BeginTransaction();
                entities.Remove(entity);
                context.SaveChanges();
                context.Database.CommitTransaction();

            }
            catch(Exception ex)
            {
                context.Database.RollbackTransaction();
            }
         
        }
        public void Remove(T entity)
        {

            try
            {
                context.Database.BeginTransaction();
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
                context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.Database.RollbackTransaction();

            }
          
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public T GetByPredicate(Func<T, bool> predicate)
        {
            return entities.FirstOrDefault(predicate);
        }
        public IList<T> GetListByPredicate(Func<T, bool> predicate)
        {
            return entities.Where(predicate).ToList();
        }

    }
}

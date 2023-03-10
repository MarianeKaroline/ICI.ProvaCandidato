using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ICI.ProvaCandidato.Dados.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        internal Context context;
        internal DbSet<TEntity> dbSet;

        public Repository(Context context) 
        { 
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);

            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Any(expression);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return dbSet.AsQueryable();
        }
    }
}

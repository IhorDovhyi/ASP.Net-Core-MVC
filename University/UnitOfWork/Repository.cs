using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace University
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Get(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbSet.Find(id);
            if (item != null)
                _dbSet.Remove(item);
        }
   
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}

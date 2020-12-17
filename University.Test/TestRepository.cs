using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.Test
{
    class TestRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public TestRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
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

        public TEntity Get(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);
        }
    }
}

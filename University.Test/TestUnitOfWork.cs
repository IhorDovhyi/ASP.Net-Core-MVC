using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.Test
{
    class TestUnitOfWork<TContext> : IUnitOfWorkOFT<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;

        public TContext DbContext => throw new NotImplementedException();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }
}
}

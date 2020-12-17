using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace University
{
    public class UnitOfWork<TContext> : IUnitOfWorkOFT<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext DbContext => _context;

        public void Save()
        {
            _context.SaveChanges();
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
    }
}

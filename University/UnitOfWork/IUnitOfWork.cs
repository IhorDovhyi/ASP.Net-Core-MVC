using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace University
{
    public interface IUnitOfWork: IDisposable
    {
       IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
       public void Save();

    }
}
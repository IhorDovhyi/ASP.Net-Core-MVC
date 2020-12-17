using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace University
{
    public interface IUnitOfWorkOFT<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext DbContext {get;}
    }
}

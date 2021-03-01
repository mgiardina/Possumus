using Possumus.Infrastructure.Data.Entities;
using Possumus.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Possumus.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Candidato> Candidatos { get; }
        IBaseRepository<Empleo> Empleos { get; }

        Task<int> CommitAsync();

        void RollBack();
    }
}

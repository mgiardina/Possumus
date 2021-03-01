using Microsoft.EntityFrameworkCore;
using Possumus.Infrastructure.Data;
using Possumus.Infrastructure.Data.Entities;
using Possumus.Infrastructure.Interfaces;
using Possumus.Infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Possumus.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IBaseRepository<Candidato> _candidatoRepository;
        private IBaseRepository<Empleo> _empleoRepository;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IBaseRepository<Candidato> Candidatos => _candidatoRepository = _candidatoRepository ?? new BaseRepository<Candidato>(_dataContext);
        public IBaseRepository<Empleo> Empleos => _empleoRepository = _empleoRepository ?? new BaseRepository<Empleo>(_dataContext);
     
        public async Task<int> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void RollBack()
        {
            _dataContext.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}

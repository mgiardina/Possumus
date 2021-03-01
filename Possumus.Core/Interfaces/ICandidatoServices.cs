using Possumus.Models.Candidato;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Possumus.Core.Interfaces
{
    public interface ICandidatoServices
    {
        Task<long> AddAsync(CandidatoModel entity);
        Task DeleteAsync(long id);
        Task<IEnumerable<CandidatoModel>> GetAllAsync();
        Task<CandidatoModel> GetByIdAsync(long id);
        Task UpdateAsync(CandidatoModel entity, long Id);
    }
}

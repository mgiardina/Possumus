using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Possumus.Core.Exceptions;
using Possumus.Core.Interfaces;
using Possumus.Infrastructure;
using Possumus.Infrastructure.Data.Entities;
using Possumus.Models.Candidato;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Possumus.Core.Services
{
    public class CandidatoServices : ICandidatoServices
    {

        private readonly IMapper _mapper;
        private readonly ILogger<CandidatoServices> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CandidatoServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<CandidatoServices> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        async Task<IEnumerable<CandidatoModel>> ICandidatoServices.GetAllAsync()
        {
            _logger.LogInformation("Leyendo todos los  Candidatos");
            var candidatos = await _unitOfWork.Candidatos.GetAllAsync();
            foreach (var candidato in candidatos)
            {
                candidato.Empleos = await _unitOfWork.Empleos.Find(e => e.CandidatoId == candidato.Id).ToListAsync();
            }
            return _mapper.Map<IEnumerable<CandidatoModel>>(candidatos);
        }

        public async Task<long> AddAsync(CandidatoModel entity)
        {
            _logger.LogInformation("Insertando Candidato");
            await _unitOfWork.Candidatos.AddAsync(_mapper.Map<Candidato>(entity));
            await _unitOfWork.CommitAsync();
            return _unitOfWork.Candidatos.GetLastInserted().Id;
        }

        public async Task UpdateAsync(CandidatoModel entity, long id)
        {
            _logger.LogInformation($"Actualizando Candidato {id}");
            var entityToBeUpdated = await _unitOfWork.Candidatos.Find(c => c.Id == id).Include(c => c.Empleos).FirstOrDefaultAsync();

            if (entityToBeUpdated == null)
                throw new BadRequestException("Candidato no existe");

            entityToBeUpdated.Nombre = entity.Nombre;
            entityToBeUpdated.Apellido = entity.Apellido;
            entityToBeUpdated.FechaNacimiento = entity.FechaNacimiento;
            entityToBeUpdated.Telefono = entity.Telefono;
            entityToBeUpdated.Email = entity.Email;

            if (entityToBeUpdated.Empleos != null)
                entityToBeUpdated.Empleos.Clear();
            entityToBeUpdated.Empleos = _mapper.Map<ICollection<Empleo>>(entity.Empleos);

            await _unitOfWork.CommitAsync();
        }

        public async Task<CandidatoModel> GetByIdAsync(long id)
        {
            _logger.LogInformation($"Leyendo Candidato {id}");
            var candidato = await _unitOfWork.Candidatos.Find(c => c.Id == id).Include(c => c.Empleos).FirstOrDefaultAsync();
            if (candidato == null)
                throw new BadRequestException("Candidato no existe");

            return _mapper.Map<CandidatoModel>(candidato);
        }


        public async Task DeleteAsync(long id)
        {
            _logger.LogInformation($"Eliminando Candidato {id}");
            var entity = await _unitOfWork.Candidatos.GetByIdAsync(id);

            if (entity == null)
                throw new BadRequestException("Candidato no se encuentra.");

            _unitOfWork.Candidatos.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}

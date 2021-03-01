using AutoMapper;
using Possumus.Infrastructure.Data.Entities;
using Possumus.Models.Candidato;
using Possumus.Models.Empleo;

namespace Possumus.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidato, CandidatoModel>();
            CreateMap<CandidatoModel, Candidato>();
            CreateMap<CandidatoRequestModel, CandidatoModel>();

            CreateMap<Empleo, EmpleoModel>();
            CreateMap<EmpleoModel, Empleo>();
            CreateMap<EmpleoRequestModel, EmpleoModel>();
        }
    }
}

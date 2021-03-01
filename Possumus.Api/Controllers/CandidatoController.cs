using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Possumus.Api.Models;
using Possumus.Api.Validators;
using Possumus.Core.Interfaces;
using Possumus.Models.Candidato;
using System.Net;
using System.Threading.Tasks;

namespace Possumus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoServices _candidatoServices;
        private readonly IMapper _mapper;

        public CandidatoController(ICandidatoServices candidatoServices, IMapper mapper)
        {
            _candidatoServices = candidatoServices;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var list = await _candidatoServices.GetAllAsync();
            return Ok(new ApiResponse(true, string.Empty, list));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> GetByIdAsync(long id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _candidatoServices.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(new ApiResponse(true, string.Empty, entity));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> CreateAsync(CandidatoRequestModel entity)
        {
            var validationResult = await new CandidatoValidator().ValidateAsync(entity);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var standId = await _candidatoServices.AddAsync(_mapper.Map<CandidatoModel>(entity));

            return Ok(new ApiResponse(true, "Candidato creado correctamente.", standId));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateAsync(long id, CandidatoRequestModel entity)
        {
            var validationResult = await new CandidatoValidator().ValidateAsync(entity);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _candidatoServices.UpdateAsync(_mapper.Map<CandidatoModel>(entity), id);

            return Ok(new ApiResponse(true, "Candidato modificado correctamente.", true));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ApiResponse>> DeleteAsync(int id)
        {
            if (id == 0)
                return NotFound();

            await _candidatoServices.DeleteAsync(id);

            return Ok(new ApiResponse(true, "Candidato eliminado correctamente.", true));
        }
    }
}
